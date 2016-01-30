using UnityEngine;
using System.Collections;

public class Token : MonoBehaviour, IPoolable {

	#region Public Properties

	#endregion

	#region Private Properties

	private int _strength;

	#endregion


	#region Accessors
	public int Strength
	{
		get
		{
			return _strength;
		}
		private set
		{
			_strength = value;
		}
	}
	#endregion


	#region Methods

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void Defend(int opposingStrength)
	{
		_strength -= opposingStrength;

		if (_strength <= 0)
		{
			PoolManager.Instance.TokenPool.Release(this);
		}
	}




	#region IPoolable

	/// <summary>
	/// Aggregates the necessary data for resetting a pooled cell.
	/// </summary>
	public class PoolData
	{
		public PoolData(Transform parentTransform, int strength)
		{
			this.Strength = strength;
			this.ParentTransform = parentTransform;
		}

		public int Strength { get; private set; }
		public Transform ParentTransform { get; private set; }
	}

	public void Consume(IPoolData _data)
	{
		TokenPoolData data = (TokenPoolData)_data;

		_strength = data.Strength;
		gameObject.SetActive(true);
		transform.SetParent(data.ParentTransform, false);
	}

	public void Release()
	{
		gameObject.SetActive(false);

	}

	#endregion

	#endregion
}
