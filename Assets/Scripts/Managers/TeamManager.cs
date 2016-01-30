using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamManager : MonoSingleton <TeamManager> {

	#region Constants
	
	#endregion
	
	#region Public Properties

	#endregion

	#region Private Properties
	[SerializeField] private int _numberOfTeams = 3;
	[SerializeField] private int _lanesPerTeam = 1;

    private List<Team> _teams = new List<Team>();
	#endregion
    
    void Awake()
    {
        for (int i = 0; i < _numberOfTeams; i++)
        {
			_teams.Add(new Team("Team " + i));
        }


		for (int i = 0; i < _lanesPerTeam; i++)
		{
			
		}
    }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
