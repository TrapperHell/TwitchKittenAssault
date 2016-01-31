using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamManager : MonoSingleton <TeamManager> {

	#region Constants
	
	#endregion
	
	#region Public Properties

	#endregion

	#region Private Properties
    [SerializeField] private List<Team> _teams = new List<Team>();
	[SerializeField] private int _startingHealth = 100;
	#endregion

	#region Accessors
	public int StartingHealth
	{
		get
		{
			return _startingHealth;
		}
	}
	#endregion
    
	protected override void AwakeEx ()
    {
        
    }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public List<Team> GetTeams()
	{
		return _teams;
	}

	public Team GetPlayerTeam(string playerName)
	{
		foreach (Team t in _teams)
		{
			if (t.HasPlayer(playerName))
			{
				return t;
			}
		}

		return null;
	}

	public void AddNewPlayer(string playerName)
	{
		int minPlayerQty = int.MaxValue;
		Team minT = _teams[0];

		foreach (Team t in _teams)
		{
			if (t.PlayerCount < minPlayerQty)
			{

				minPlayerQty = t.PlayerCount;
				minT = t;
			}
		}

		minT.RegisterPlayer(playerName);
	}

	public void AddNewPlayer(string playerName, Team t)
	{
		t.RegisterPlayer(playerName);
	}

	public void Vote(string playerName)
	{
		foreach (Team t in _teams)
		{
			if (t.HasPlayer(playerName))
			{
				t.Vote();
				break;
			}
		}
	}
		
}
