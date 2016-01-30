using System.Collections.Generic;

public class Lane {

	#region Public Properties

	#endregion

	#region Private Properties
	private int _laneName;
	private Team _team1;
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

	#endregion


	#region Methods
	public Lane(int laneName, Team team1, Team team2)
	{
		_laneName = laneName;
		_team1 = team1;
		_team2 = team2;

		_team1Players = new List<string>();
		_team2Players = new List<string>();
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


	#endregion

}
