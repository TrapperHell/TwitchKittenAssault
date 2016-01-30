using UnityEngine;
using System.Collections;

public class GameLogicController : MonoSingleton <GameLogicController> {

	#region Constants
	const string musicSetting = "playerSettingMusic";
	const string sfxSetting = "playerSettingSfx";
	#endregion
	
	
	#region Public Properties
	public int tokenInitialPoolSize = 10;
	#endregion

	#region Private Properties

	#endregion

	#if MASTER_DEBUG

	#endif
	


	
	#region Accessors

	#endregion
	
	
	#region Methods
	void Start () {
		
	}
	
	protected override void AwakeEx () {
			
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
		D.log("Data path: " + Application.dataPath);
		D.log("Persistent data path: " + Application.persistentDataPath);
		
		D.log("Screen size: " + Screen.width + ", " + Screen.height);
		//D.log("Game version: " + GetVersion());

	}
	
	void Update () {
		
		#if MASTER_DEBUG
		//Dev cheats go here


		
		#endif
		
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
