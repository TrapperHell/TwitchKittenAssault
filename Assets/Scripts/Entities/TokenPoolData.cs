using UnityEngine;


public class TokenPoolData : IPoolData
{

	#region Private Properties
	private Transform _parentTransform;
	private int _strength;

	#endregion


	public TokenPoolData(Transform parentTransform, int strength)
	{
		_parentTransform = parentTransform;
		_strength = strength;
	}

	#region Accessors

	public Transform ParentTransform
	{
		get
		{
			return _parentTransform;
		}
	}

	public int Strength
	{
		get
		{
			return _strength;
		}
	}

	#endregion
}