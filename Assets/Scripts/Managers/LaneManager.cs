﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaneManager : Singleton <LaneManager> {

	#region Constants

	#endregion

	#region Public Properties

	#endregion

	#region Private Properties


	private List<Lane> _lanes = new List<Lane>();
	#endregion

	public void AddLane(Team t1, Team t2)
	{
		_lanes.Add(new Lane(_lanes.Count, t1, t2));
	}

	public List<Lane> GetLanes()
	{
		return _lanes;
	}

	public List<Lane> GetTeamLanes(Team t)
	{
		List<Lane> teamLanes = new List<Lane>();
		foreach (Lane l in _lanes)
		{
			if (l.ConnectedToTeam(t))
			{
				teamLanes.Add(l);
			}
		}

		return teamLanes;
	}
}
