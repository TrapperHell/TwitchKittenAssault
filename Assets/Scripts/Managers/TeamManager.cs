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
}
