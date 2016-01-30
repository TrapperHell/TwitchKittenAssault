using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoSingleton <GameController> {

	#region Constants

	#endregion

	#region Public Properties

	#endregion

	#region Private Properties
	[SerializeField] private float _pulseIntervalInMs = 1000;

	private float _lastPulseTime;
	#endregion

	protected override void AwakeEx () {
		_lastPulseTime = 0;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Time.time > _lastPulseTime + _pulseIntervalInMs)
		{
			_lastPulseTime = Time.time;

			FirePulse();
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
			
		}
	}
}
