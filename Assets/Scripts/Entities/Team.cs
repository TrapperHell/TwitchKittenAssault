using System.Collections.Generic;
using UnityEngine;

public class Team {

	#region Public Properties

	#endregion

	#region Private Properties
	private string _teamName;
	private List<string> _players;

	private RectTransform _rectTransform;
	#endregion

	#region Accessors
	public string Name
	{
		get
		{
			return _teamName;
		}
		set
		{
			_teamName = value;
		}
	}

	public int PlayerCount
	{
		get
		{
			return _players.Count;
		}
	}

	public RectTransform TeamBase
	{
		get
		{
			return _rectTransform;
		}
	}
	#endregion

	#region Methods
	public Team(string teamName)
	{
		_teamName = teamName;
		_players = new List<string>();
	}

	public List<string> GetPlayers()
	{
		return _players;
	}

	public void RegisterPlayer(string playerName)
	{
		if (_players.Contains(playerName) == false)
		{
			_players.Add(playerName);
		}
	}

	public bool HasPlayer(string playerName)
	{
		return _players.Contains(playerName);
	}


	#endregion

}
