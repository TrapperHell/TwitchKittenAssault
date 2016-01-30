using UnityEngine;

public class Singleton <T> where T : class, new () {

	#region Static Properties
	private static T _instance;
	public static T Instance {get{if (_instance == null) new T (); return _instance;}}
	#endregion


	#region Methods
	public Singleton()
	{
		if (_instance != null)
		{
			return;
		}

		_instance = this as T;
		Reset ();
	}


	public virtual void Reset () { }
	#endregion

}