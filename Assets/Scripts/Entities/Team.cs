public class Team {

	#region Public Properties

	#endregion

	#region Private Properties
	private string _teamName;
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
	#endregion

	#region Methods
	public Team(string teamName)
	{
		_teamName = teamName;
	}

	public void RegisterLane(string tempforName, Lane lane)
	{
	}
	#endregion

}
