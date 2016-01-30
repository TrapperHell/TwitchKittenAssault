using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestingDataModel : MonoBehaviour {

	public int numPlayers = 10;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numPlayers; i++)
		{
			GameController.Instance.RegisterPlayer("player " + i);
		}

		D.log("TEAM MEMBERSHIP");

		string output = "";
		foreach (Team t in TeamManager.Instance.GetTeams())
		{
			
			output = t.Name + "\r\n";

			foreach (string playerName in t.GetPlayers())
			{
				output += "|" + playerName + "|";
			}

			output += "\r\n";

			D.log(output);
		}

		RandomiseLanes();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void RandomiseLanes()
	{

		D.log("LANE SPLIT");

		string output = "";
		foreach (Team t in TeamManager.Instance.GetTeams())
		{
			output = t.Name + "\r\n";
			List<Lane> lanes = LaneManager.Instance.GetTeamLanes(t);
			foreach (string playerName in t.GetPlayers())
			{
				int laneName = lanes[Random.Range(0, lanes.Count)].LaneName;
				GameController.Instance.GoToLane(playerName, laneName);

				output += "|" + playerName + " - Lane " + laneName + "|";
			}
			output += "\r\n";

			D.log(output);
		}

		D.log("LANE FINAL");


		foreach (Lane l in LaneManager.Instance.GetLanes())
		{

			output = "Lane " + l.LaneName + "\r\n";

			output += l.Team1.Name + " ----> ";
			foreach (string playerName in l.GetTeam1Players())
			{
				output += "|" + playerName + "|";
			}


			output += "\r\n" + l.Team2.Name + " ----> ";
			foreach (string playerName in l.GetTeam2Players())
			{
				output += "|" + playerName + "|";
			}

			output += "\r\n";

			D.log(output);
		}


	}
}
