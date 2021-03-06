﻿using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoSingleton<LaneManager>
{
    #region Constants

    #endregion

    #region Public Properties

    #endregion

    #region Private Properties
    [SerializeField]
    private List<Lane> _lanes;
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