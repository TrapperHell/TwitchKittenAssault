using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
	#region Public Properties

	#endregion

	#region Private Properties
    [SerializeField]
    private int _laneName;
    [SerializeField]
    private Team _team1;
    [SerializeField]
    private Team _team2;

	private List<string> _team1Players;
	private List<string> _team2Players;
	#endregion

	#region Accessors
	public int LaneName
	{
		get
		{
			return _laneName;
		}
	}

	public Team Team1
	{
		get
		{
			return _team1;
		}
	}

	public Team Team2
	{
		get
		{
			return _team2;
		}
	}

	public int Team1Strength
	{
		get
		{
			return _team1Players.Count;
		}
	}

	public int Team2Strength
	{
		get
		{
			return _team2Players.Count;
		}
	}

	#endregion


	#region Methods
	void Awake()
	{
		_team1Players = new List<string>();
		_team2Players = new List<string>();
	}

	void Start()
	{
	}

	public bool ConnectedToTeam(Team t)
	{
		if ((t == _team1) || (t == _team2))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool HasPlayer(string playerName)
	{
		if (_team1Players.Contains(playerName) || _team2Players.Contains(playerName))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void RemovePlayer(string playerName)
	{
		_team1Players.Remove(playerName);
		_team2Players.Remove(playerName);
	}

	public void AddPlayer(string playerName)
	{
		if (_team1.HasPlayer(playerName))
		{
			if (_team1Players.Contains(playerName) == false)
			{
				_team1Players.Add(playerName);
			}
		}
		else if (_team2.HasPlayer(playerName))
		{
			if (_team2Players.Contains(playerName) == false)
			{
				_team2Players.Add(playerName);
			}
		}
	}

	public List<string> GetTeam1Players()
	{
		return _team1Players;
	}


	public List<string> GetTeam2Players()
	{
		return _team2Players;
	}

	public void FirePulse()
	{
		Vector3 t1Pos = _team1.TeamBase.position;
		Vector3 t2Pos = _team2.TeamBase.position;

		if ((Team1Strength > 0) && (_team1.Health > 0))
		{
			Token team1Token = PoolManager.Instance.TokenPool.Consume(new TokenPoolData(transform, Team1Strength, _team1));
			team1Token.transform.position = t1Pos;
			WaypointControl.TokenMoveManager.Instance.MoveToken(team1Token.gameObject, _team1.Name, _team2.Name);
		}

		if ((Team2Strength > 0) && (_team2.Health > 0))
		{
			Token team2Token = PoolManager.Instance.TokenPool.Consume(new TokenPoolData(transform, Team2Strength, _team2));
			team2Token.transform.position = t2Pos;
			WaypointControl.TokenMoveManager.Instance.MoveToken(team2Token.gameObject, _team2.Name, _team1.Name);
		}


	}

	#endregion
}
