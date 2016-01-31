using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoSingleton<GameController>
{
    #region Constants

    #endregion

    #region Public Properties
	public Text num3;
	public Text num2;
	public Text num1;
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
	[SerializeField] private int _voteHealAmount = 100;

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

	public string CurrentEmoticon
	{
		get
		{
			return _emoticon.CurrentEmoticon();
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

		if ((Time.time >= _nextVoteTime - 3) && (Time.time < _nextVoteTime - 2))
		{
			num3.gameObject.SetActive(true);
		}
		else if ((Time.time >= _nextVoteTime - 2) && (Time.time < _nextVoteTime - 1))
		{
			num3.gameObject.SetActive(false);
			num2.gameObject.SetActive(true);
		}
		else if ((Time.time >= _nextVoteTime - 1) && (Time.time < _nextVoteTime - 0))
		{
			num2.gameObject.SetActive(false);
			num1.gameObject.SetActive(true);
		}
		else if (Time.time >= _nextVoteTime)
		{
			num1.gameObject.SetActive(false);

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

	public void EndVote()
	{
		int maxVote = -1;
		Team tMax = TeamManager.Instance.GetTeams()[Random.Range(0, TeamManager.Instance.GetTeams().Count)];
		foreach (Team t in TeamManager.Instance.GetTeams())
		{
			if ((t.Votes > 0) && (t.Votes > maxVote))
			{
				tMax = t;
			}
		}

		if (Random.Range(0, 2) == 0)
		{
			tMax.KillOtherTokens();
		}
		else
		{
			tMax.Heal(_voteHealAmount);
		}
	}
}