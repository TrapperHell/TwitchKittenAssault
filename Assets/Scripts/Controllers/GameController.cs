﻿using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    #region Constants

    #endregion

    #region Public Properties

    #endregion

    #region Private Properties
    [SerializeField]
    private float _pulseIntervalInS = 1;
    [SerializeField]
    private float _voteTimeInS = 5;
    [SerializeField]
    private float _voteIntervalMinInS = 45;
    [SerializeField]
    private float _voteIntervalMaxInS = 60;
	[SerializeField] private Emoticon _emoticon;

    private float _lastPulseTime;
    private float _lastVoteTime;
    private float _nextVoteTime;
    #endregion

	public float VoteTime
	{		get
		{
			return _voteTimeInS;
		}
	}

    protected override void AwakeEx()
    {
        _lastPulseTime = 0;
        _lastVoteTime = 0;
        _nextVoteTime = Random.Range(_voteIntervalMinInS, _voteIntervalMaxInS);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= _lastPulseTime + _pulseIntervalInS)
        {
            _lastPulseTime = Time.time;

            FirePulse();
        }

        if (Time.time >= _nextVoteTime)
        {
            StartVote();
            _lastVoteTime = Time.time;
            _nextVoteTime = Time.time + Random.Range(_voteIntervalMinInS, _voteIntervalMaxInS);
        }
    }

    public void RegisterPlayer(string playerName)
    {
        TeamManager.Instance.AddNewPlayer(playerName);
    }

    public void GoToLane(string playerName, int laneName)
    {
        Team t = TeamManager.Instance.GetPlayerTeam(playerName);

        if (t != null)
        {
            List<Lane> lanes = LaneManager.Instance.GetTeamLanes(t);

            foreach (Lane l in lanes)
            {
                if (l.ConnectedToTeam(t))
                {
                    //Switch the lane
                    if (l.LaneName == laneName)
                    {
                        l.AddPlayer(playerName);
                    }
                    else
                    {
                        l.RemovePlayer(playerName);
                    }
                }
            }
        }
    }

    private void FirePulse()
    {
        List<Lane> lanes = LaneManager.Instance.GetLanes();

        foreach (Lane l in lanes)
        {
            l.FirePulse();
        }
    }

	public void Vote(string playerName)
    {
        if ((Time.time >= _lastVoteTime) && (Time.time <= _lastVoteTime + _voteTimeInS))
        {
            TeamManager.Instance.Vote(playerName);
        }
    }

    public void StartVote()
    {
        foreach (Team t in TeamManager.Instance.GetTeams())
        {
            t.ClearVotes();
        }

		_emoticon.NewEmoticon();
		_emoticon.gameObject.SetActive(true);

    }
}