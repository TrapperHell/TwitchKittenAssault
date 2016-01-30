public class Lane {

	#region Public Properties

	#endregion

	#region Private Properties

	#endregion


	#region Methods
	public Lane(Team team1, Team team2)
	{
		team1.RegisterLane("sgakgksajgak", this);
		team2.RegisterLane("sgakgksajgak", this);
	}

	public void RegisterLane(string tempforName, Lane lane)
	{
	}
	#endregion

}
