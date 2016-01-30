using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Transform))]
public class Team : MonoBehaviour {

	#region Public Properties

	#endregion

	#region Private Properties
	[SerializeField] private string _teamName;

	private List<string> _players;
	private Transform _transform;
	private int _health;
	#endregion

	#region Accessors
	public string Name
	{
		get
		{
			return _teamName;
		}
		set
		{
			_teamName = value;
		}
	}

	public int PlayerCount
	{
		get
		{
			return _players.Count;
		}
	}

	public Transform TeamBase
	{
		get
		{
			return _transform;
		}
	}
	#endregion

	#region Methods
	void Awake()
	{
		_transform = GetComponent<Transform>();
		_players = new List<string>();
		_health = TeamManager.Instance.StartingHealth;
	}

	void Start()
	{
		
	}

	public List<string> GetPlayers()
	{
		return _players;
	}

	public void RegisterPlayer(string playerName)
	{
		if (_players.Contains(playerName) == false)
		{
			_players.Add(playerName);

			List<Lane> lanes = LaneManager.Instance.GetTeamLanes(this);

			GameController.Instance.GoToLane(playerName, lanes[Random.Range(0, lanes.Count)].LaneName);

			_players.Sort();
			//TODO: update UI list of names
		}
	}

	public bool HasPlayer(string playerName)
	{
		return _players.Contains(playerName);
	}

	public void Hit(int tokenStrength)
	{
		_health -= tokenStrength;

		if (_health <= 0)
		{
			//TODO: DESTROY BASE!!!
			D.log("BASE DESTROYED!!! - Team: " + _teamName);
		}
	}

	#endregion

}
