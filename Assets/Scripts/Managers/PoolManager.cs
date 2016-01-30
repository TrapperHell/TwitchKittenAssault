using UnityEngine;
using System.Collections;

/// <summary>
/// MonoBehaviour which pools other MonoBehaviours for reuse.
/// </summary>
public class PoolManager : MonoSingleton <PoolManager> {

		
	#region Public properties

	#endregion

	#region Private Properties
	[SerializeField] private Token _tokenPrefab;
	[SerializeField] private Transform _tokenPoolParent;

	private ObjectPool<Token> _tokenPool;

	#endregion

	
	#region Accessors

	/// <summary>
	/// Cell Pool.
	/// </summary>
	/// <value>The Cell pool.</value>
	public ObjectPool<Token> TokenPool
	{
		get
		{
			return _tokenPool;
		}
	}

	#endregion
	
	
	#region Methods

	protected override void AwakeEx ()
	{
		_tokenPool = new ObjectPool<Token>(_tokenPrefab, _tokenPoolParent);
		_tokenPool.ResizePool(GameLogicController.Instance.TEMPtokenpoolsize);
	}

	void Update()
	{

	}


	#endregion
	
}
