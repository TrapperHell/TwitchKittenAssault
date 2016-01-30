﻿using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (RectTransform))]
public class Team : MonoBehaviour {

	#region Public Properties

	#endregion

	#region Private Properties
	[SerializeField] private string _teamName;

	private List<string> _players;
	private RectTransform _rectTransform;
	private int _health;
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
	void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
		_players = new List<string>();
		_health = TeamManager.Instance.StartingHealth;
	}

	void Start()
	{
		
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

	private void Hit(int tokenStrength)
	{
		_health -= tokenStrength;

		if (_health <= 0)
		{
			//TODO: DESTROY BASE!!!;
		}
	}

	#endregion

}
