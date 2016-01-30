using UnityEngine;
using System.Collections;

public class GameLogicController : MonoSingleton <GameLogicController> {

	#region Constants
	const string musicSetting = "playerSettingMusic";
	const string sfxSetting = "playerSettingSfx";
	#endregion
	
	
	#region Public Properties
	public int TEMPtokenpoolsize = 10;
	public Transform TEMPactivetokenparent;
	#endregion

	#region Private Properties
	[SerializeField] private string _gameVersion = "0.1";

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
