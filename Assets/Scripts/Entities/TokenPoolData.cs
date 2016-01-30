using UnityEngine;


public class TokenPoolData : IPoolData
{

	#region Private Properties
	private Transform _parentTransform;
	private int _strength;
	private Team _sourceTeam;

	#endregion


	public TokenPoolData(Transform parentTransform, int strength, Team sourceTeam)
	{
		_parentTransform = parentTransform;
		_strength = strength;
		_sourceTeam = sourceTeam;
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

	public Team SourceTeam
	{
		get
		{
			return _sourceTeam;
		}
	}	#endregion
}