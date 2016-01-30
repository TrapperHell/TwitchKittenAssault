using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Pools objects of type T in order to recycle objects rather than continuously instantiating/destroying them.
/// </summary>
public class ObjectPool<T> where T : MonoBehaviour, IPoolable//, new()
{
	#region Private properties
	private List<T> _pool;
	private List<T> _inUse;

	private T _objectPrefab;
	private Transform _objectParent;
	#endregion

	#region Accessors
	public int PoolSize
	{
		get
		{
			return _pool.Count;
		}
	}
	#endregion

	#region Methods
	/// <summary>
	/// Initializes a new instance of the <see cref="ObjectPool`1"/> class for the provided prefab.
	/// </summary>
	/// <param name="objectPrefab">Unity prefab.</param>
	/// <param name="objectParent">Default parent object for which pooled objects will be instantiated under.</param>
	public ObjectPool(T objectPrefab, Transform objectParent)
	{
		_pool = new List<T>();
		_inUse = new List<T>();

		_objectPrefab = objectPrefab;
		_objectParent = objectParent;
	}
	
	public void ResizePool(int poolSize)
	{
		ResizePool(poolSize, 0.0f);
	}

	/// <summary>
	/// Resizes the pool and constructs/destroys instances to fit the new size.
	/// </summary>
	/// <param name="poolSize">The new pool size.</param>
	/// <param name="percentageExtra">Percentage extra.</param>
	public void ResizePool(int poolSize, float percentageExtra)
	{
		int adjustedPoolSize = Mathf.RoundToInt(poolSize * (1 + percentageExtra));

		if (_pool.Count > adjustedPoolSize)
		{
			_pool.RemoveRange(adjustedPoolSize, _pool.Count - adjustedPoolSize);
		}
		else
		{
			for (int i = _pool.Count; i < adjustedPoolSize; i++)
			{
				Create();
			}
		}
	}

	/// <summary>
	/// Provides a pooled instance.
	/// </summary>
	/// <param name="data">Optional parameter provided to the returned instance for resetting its internal state.</param>
	public T Consume(IPoolData data)
	{
		T obj;

		if (_pool.Count > 0)
		{
			obj = _pool[0];
		}
		else
		{
			obj = Create();
		}

		_pool.Remove(obj);
		_inUse.Add(obj);

		obj.Consume(data);

		return obj;
	}

	/// <summary>
	/// Release the specified object and returns it into this pool.
	/// </summary>
	/// <param name="obj">The object to release.</param>
	public void Release(T obj)
	{
		obj.Release();

		_inUse.Remove(obj);
		if (_pool.Contains(obj) == false)
		{
			_pool.Add(obj);
		}

		obj.transform.SetParent(_objectParent, false);
	}

	/// <summary>
	/// Creates a new instance.
	/// </summary>
	private T Create()
	{
		T obj = Object.Instantiate(_objectPrefab);

		obj.gameObject.SetActive(false);

		_pool.Add(obj);
	
		obj.transform.SetParent(_objectParent, false);

		return obj;
	}


	#endregion
	
}