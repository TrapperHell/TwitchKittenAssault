using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamManager : MonoSingleton <TeamManager> {

	#region Constants
	
	#endregion
	
	#region Public Properties

	#endregion

	#region Private Properties
	[SerializeField][Range(1, 5)] private int _numberOfTeams = 3;
	[SerializeField][Range(1, 5)] private int _lanesPerTeam = 1;

    private List<Team> _teams = new List<Team>();
	#endregion
    
	protected override void AwakeEx ()
    {
        for (int i = 0; i < _numberOfTeams; i++)
        {
			Team tNew = new Team("Team " + i);

			foreach (Team t in _teams)
			{
				for (int l = 0; l < _lanesPerTeam; l++)
				{
					LaneManager.Instance.AddLane(l, tNew, t);
				}
			}

			_teams.Add(tNew);
        }
    }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
		int minPlayerQty = -1;
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
