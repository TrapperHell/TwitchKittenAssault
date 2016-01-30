using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaneManager : MonoSingleton <LaneManager> {

	#region Constants

	#endregion

	#region Public Properties

	#endregion

	#region Private Properties
	[SerializeField] private Lane _lanePrefab;


	[SerializeField] private List<Lane> _lanes;
	#endregion

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
