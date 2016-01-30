using UnityEngine;
using System.Collections;

public class Token : MonoBehaviour, IPoolable {

	#region Public Properties

	#endregion

	#region Private Properties
	[SerializeField] private string _tokenTag = "Token";
	[SerializeField] private string _baseTag = "Base";
	private int _strength;
	private Team _sourceTeam;

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

	public Team SourceTeam
	{
		get
		{
			return _sourceTeam;
		}
		private set
		{
			_sourceTeam = value;
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

	void OnTriggerEnter2D(Collider2D collider)
	{
		/*
			ASSUMPTION:
			When 2 tokens collide, we can assume that either one or both will be destroyed.
			We can use this assumption to resolve the collision in just one token (since it will normally be triggered in both)
		*/

		if (string.Equals(collider.tag.ToLower(), _tokenTag.ToLower()))
		{
			Token other = collider.GetComponent<Token>();
			if (other != null)
			{
				if (_sourceTeam != other.SourceTeam)
				{
					int thisStrength = Strength;
					int otherStrength = other.Strength;

					if (thisStrength >= otherStrength)
					{
						//See assumption above
						other.GetHit(thisStrength);
						GetHit(otherStrength);
					}
				}
			}
		}
		else if (string.Equals(collider.tag.ToLower(), _baseTag.ToLower()))
		{
			Team t = collider.GetComponent<Team>();
			if (t != null)
			{
				if (t != _sourceTeam)
				{
					t.Hit(Strength);

					_strength = 0; //Just to be safe
					PoolManager.Instance.TokenPool.Release(this);
				}
			}
		}
	}

	private void GetHit(int opposingStrength)
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
		public PoolData(Transform parentTransform, int strength, Team sourceTeam)
		{
			this.Strength = strength;
			this.ParentTransform = parentTransform;
			this.SourceTeam = sourceTeam;
		}

		public int Strength { get; private set; }
		public Transform ParentTransform { get; private set; }
		public Team SourceTeam { get; private set; }
	}

	public void Consume(IPoolData _data)
	{
		TokenPoolData data = (TokenPoolData)_data;

		_strength = data.Strength;
		_sourceTeam = data.SourceTeam;
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
