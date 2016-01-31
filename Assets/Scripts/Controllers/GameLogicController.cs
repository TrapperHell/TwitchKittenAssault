using UnityEngine;
using System.Collections;

public class GameLogicController : MonoSingleton <GameLogicController> {

	#region Constants
	const string musicSetting = "playerSettingMusic";
	const string sfxSetting = "playerSettingSfx";
	#endregion
	
	
	#region Public Properties
	public int tokenInitialPoolSize = 10;
	public TwitchIRC twitchChat;
	#endregion

	#region Private Properties

	#endregion

	#if MASTER_DEBUG

	#endif
	


	
	#region Accessors

	#endregion
	
	
	#region Methods
	void Start () {
		twitchChat.messageRecievedEvent.AddListener(Assets.Scripts.Managers.ChatManager.ParseRawMessage);
	}
	
	protected override void AwakeEx () {
			
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
		D.log("Data path: " + Application.dataPath);
		D.log("Persistent data path: " + Application.persistentDataPath);
		
		D.log("Screen size: " + Screen.width + ", " + Screen.height);
		//D.log("Game version: " + GetVersion());

	}
	
	void Update () {
		
		//Dev cheats go here

		string playerName = "";
		int lane = -1;
		Team t = TeamManager.Instance.GetTeams()[0];
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			playerName = Random.Range(0, 1000000).ToString();
			t = TeamManager.Instance.GetTeams()[0];
			lane = 1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			playerName = Random.Range(0, 1000000).ToString();
			t = TeamManager.Instance.GetTeams()[1];
			lane = 2;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			playerName = Random.Range(0, 1000000).ToString();
			t = TeamManager.Instance.GetTeams()[2];
			lane = 3;
		}
		if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			playerName = Random.Range(0, 1000000).ToString();
			t = TeamManager.Instance.GetTeams()[0];
			lane = 3;
		}
		if (Input.GetKeyDown(KeyCode.Alpha9))
		{
			playerName = Random.Range(0, 1000000).ToString();
			t = TeamManager.Instance.GetTeams()[2];
			lane = 2;
		}
		if (Input.GetKeyDown(KeyCode.Alpha8))
		{
			playerName = Random.Range(0, 1000000).ToString();
			t = TeamManager.Instance.GetTeams()[1];
			lane = 1;
		}

		if (lane != -1)
		{
			TeamManager.Instance.AddNewPlayer(playerName, t);
			GameController.Instance.GoToLane(playerName, lane);
		}
		
		
	}
	
	void OnApplicationQuit () {
		
		//Cleanup goes here, eg. destroy timers
		
	}
	
	
/*	public string GetVersion () {
		
		return _gameVersion;
		
	}
*/
	#endregion
	
}
