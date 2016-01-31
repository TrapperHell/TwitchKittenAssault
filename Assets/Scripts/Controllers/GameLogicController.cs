using UnityEngine;
using System.Collections;

public class GameLogicController : MonoSingleton<GameLogicController>
{
    #region Constants
    const string musicSetting = "playerSettingMusic";
    const string sfxSetting = "playerSettingSfx";
    #endregion


    #region Public Properties
    public int tokenInitialPoolSize = 10;
    public TwitchIRC twitchChat;
    #endregion

    #region Private Properties
	private string[] usernames = new string[] { "Faitherpuce", "Famouserci", "FamousUnique", "Fangtecnet", "FantasticSlim", "Faroebasnob", "Farratesyla", "Fastersie", "FerdyLuc", "FlamesSpecial", "Flatnes", "Flatortq", "Flearpayal", "Fleterfo", "Fogarac", "Fraserinte", "FunnySly", "GameSosa", "Gaoldisr", "GazetteBrood", "GiveGlossyVampire", "Godetroadix", "GoobleDance", "GotRoses", "Goutaherge", "Grantegisma", "GreatByteRox", "Greedodode", "GreyBing", "Griffontria", "Guldgram", "Hanmicrimag", "HanRadiant", "Heartanom", "Heatelem", "HeheBlaze", "HelloPhobic", "Heroofunde", "HighFinest", "Hightsta", "Hionettier", "HockeyCutie", "HockeyJan", "Faitherpuce", "Famouserci", "FamousUnique", "Fangtecnet", "FantasticSlim", "Faroebasnob", "Farratesyla", "Fastersie", "FerdyLuc", "FlamesSpecial", "Flatnes", "Flatortq", "Flearpayal", "Fleterfo", "Fogarac", "Fraserinte", "FunnySly", "GameSosa", "Gaoldisr", "GazetteBrood", "GiveGlossyVampire", "Godetroadix", "GoobleDance", "GotRoses", "Goutaherge", "Grantegisma", "GreatByteRox", "Greedodode", "GreyBing", "Griffontria", "Guldgram", "Hanmicrimag", "HanRadiant", "Heartanom", "Heatelem", "HeheBlaze", "HelloPhobic", "Heroofunde", "HighFinest", "Hightsta", "Hionettier", "HockeyCutie", "HockeyJan", "Faitherpuce", "Famouserci", "FamousUnique", "Fangtecnet", "FantasticSlim", "Faroebasnob", "Farratesyla", "Fastersie", "FerdyLuc", "FlamesSpecial", "Flatnes", "Flatortq", "Flearpayal", "Fleterfo", "Fogarac", "Fraserinte", "FunnySly", "GameSosa", "Gaoldisr", "GazetteBrood", "GiveGlossyVampire", "Godetroadix", "GoobleDance", "GotRoses", "Goutaherge", "Grantegisma", "GreatByteRox", "Greedodode", "GreyBing", "Griffontria", "Guldgram", "Hanmicrimag", "HanRadiant", "Heartanom", "Heatelem", "HeheBlaze", "HelloPhobic", "Heroofunde", "HighFinest", "Hightsta", "Hionettier", "HockeyCutie", "HockeyJan", "Faitherpuce", "Famouserci", "FamousUnique", "Fangtecnet", "FantasticSlim", "Faroebasnob", "Farratesyla", "Fastersie", "FerdyLuc", "FlamesSpecial", "Flatnes", "Flatortq", "Flearpayal", "Fleterfo", "Fogarac", "Fraserinte", "FunnySly", "GameSosa", "Gaoldisr", "GazetteBrood", "GiveGlossyVampire", "Godetroadix", "GoobleDance", "GotRoses", "Goutaherge", "Grantegisma", "GreatByteRox", "Greedodode", "GreyBing", "Griffontria", "Guldgram", "Hanmicrimag", "HanRadiant", "Heartanom", "Heatelem", "HeheBlaze", "HelloPhobic", "Heroofunde", "HighFinest", "Hightsta", "Hionettier", "HockeyCutie", "HockeyJan", "Faitherpuce", "Famouserci", "FamousUnique", "Fangtecnet", "FantasticSlim", "Faroebasnob", "Farratesyla", "Fastersie", "FerdyLuc", "FlamesSpecial", "Flatnes", "Flatortq", "Flearpayal", "Fleterfo", "Fogarac", "Fraserinte", "FunnySly", "GameSosa", "Gaoldisr", "GazetteBrood", "GiveGlossyVampire", "Godetroadix", "GoobleDance", "GotRoses", "Goutaherge", "Grantegisma", "GreatByteRox", "Greedodode", "GreyBing", "Griffontria", "Guldgram", "Hanmicrimag", "HanRadiant", "Heartanom", "Heatelem", "HeheBlaze", "HelloPhobic", "Heroofunde", "HighFinest", "Hightsta", "Hionettier", "HockeyCutie", "HockeyJan", "Faitherpuce", "Famouserci", "FamousUnique", "Fangtecnet", "FantasticSlim", "Faroebasnob", "Farratesyla", "Fastersie", "FerdyLuc", "FlamesSpecial", "Flatnes", "Flatortq", "Flearpayal", "Fleterfo", "Fogarac", "Fraserinte", "FunnySly", "GameSosa", "Gaoldisr", "GazetteBrood", "GiveGlossyVampire", "Godetroadix", "GoobleDance", "GotRoses", "Goutaherge", "Grantegisma", "GreatByteRox", "Greedodode", "GreyBing", "Griffontria", "Guldgram", "Hanmicrimag", "HanRadiant", "Heartanom", "Heatelem", "HeheBlaze", "HelloPhobic", "Heroofunde", "HighFinest", "Hightsta", "Hionettier", "HockeyCutie", "HockeyJan", "Faitherpuce", "Famouserci", "FamousUnique", "Fangtecnet", "FantasticSlim", "Faroebasnob", "Farratesyla", "Fastersie", "FerdyLuc", "FlamesSpecial", "Flatnes", "Flatortq", "Flearpayal", "Fleterfo", "Fogarac", "Fraserinte", "FunnySly", "GameSosa", "Gaoldisr", "GazetteBrood", "GiveGlossyVampire", "Godetroadix", "GoobleDance", "GotRoses", "Goutaherge", "Grantegisma", "GreatByteRox", "Greedodode", "GreyBing", "Griffontria", "Guldgram", "Hanmicrimag", "HanRadiant", "Heartanom", "Heatelem", "HeheBlaze", "HelloPhobic", "Heroofunde", "HighFinest", "Hightsta", "Hionettier", "HockeyCutie" };
		
    #endregion

#if MASTER_DEBUG

#endif

    #region Accessors

    #endregion


    #region Methods

    void Start()
    {
        if (twitchChat == null)
            return;

        twitchChat.messageRecievedEvent.AddListener(Assets.Scripts.Managers.ChatManager.ParseRawMessage);
    }

    protected override void AwakeEx()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        D.log("Data path: " + Application.dataPath);
        D.log("Persistent data path: " + Application.persistentDataPath);

        D.log("Screen size: " + Screen.width + ", " + Screen.height);
        //D.log("Game version: " + GetVersion());

    }

    void Update()
    {
        //Dev cheats go here

		if (Input.GetKeyDown(KeyCode.W))
		{
			TeamManager.Instance.AddNewPlayer(usernames[Random.Range(0, usernames.Length)], TeamManager.Instance.GetTeams()[0]);
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			GameController.Instance.GoToLane(TeamManager.Instance.GetTeams()[0].GetRandomPlayer(), 1);
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			GameController.Instance.GoToLane(TeamManager.Instance.GetTeams()[0].GetRandomPlayer(), 3);
		}


		if (Input.GetKeyDown(KeyCode.B))
		{
			TeamManager.Instance.AddNewPlayer(usernames[Random.Range(0, usernames.Length)], TeamManager.Instance.GetTeams()[1]);
		}
		if (Input.GetKeyDown(KeyCode.V))
		{
			GameController.Instance.GoToLane(TeamManager.Instance.GetTeams()[1].GetRandomPlayer(), 1);
		}
		if (Input.GetKeyDown(KeyCode.N))
		{
			GameController.Instance.GoToLane(TeamManager.Instance.GetTeams()[1].GetRandomPlayer(), 2);
		}


		if (Input.GetKeyDown(KeyCode.O))
		{
			TeamManager.Instance.AddNewPlayer(usernames[Random.Range(0, usernames.Length)], TeamManager.Instance.GetTeams()[2]);
		}
		if (Input.GetKeyDown(KeyCode.I))
		{
			GameController.Instance.GoToLane(TeamManager.Instance.GetTeams()[0].GetRandomPlayer(), 2);
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			GameController.Instance.GoToLane(TeamManager.Instance.GetTeams()[0].GetRandomPlayer(), 3);
		}



		/*
		string playerName = usernames[Random.Range(0, usernames.Length)];
        int lane = -1;
        Team t = TeamManager.Instance.GetTeams()[0];
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            t = TeamManager.Instance.GetTeams()[0];
            lane = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            t = TeamManager.Instance.GetTeams()[1];
            lane = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            t = TeamManager.Instance.GetTeams()[2];
            lane = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            t = TeamManager.Instance.GetTeams()[0];
            lane = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            t = TeamManager.Instance.GetTeams()[2];
            lane = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            t = TeamManager.Instance.GetTeams()[1];
            lane = 1;
        }

        if (lane != -1)
        {
            TeamManager.Instance.AddNewPlayer(playerName, t);
            GameController.Instance.GoToLane(playerName, lane);
        }
*/

    }

    void OnApplicationQuit()
    {
        //Cleanup goes here, eg. destroy timers
    }


    /*	public string GetVersion () {

            return _gameVersion;

        }
    */
    #endregion
}