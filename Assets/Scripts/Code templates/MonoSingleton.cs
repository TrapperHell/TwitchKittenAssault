using UnityEngine;

public class MonoSingleton <T> : MonoBehaviour where T : MonoSingleton <T> {

	#region Static Variables
	private static T _instance;
	public static T Instance {get{return _instance;}}
	#endregion


	#region Methods
	void Awake()
	{
		if (_instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			_instance = this as T;
			DontDestroyOnLoad(this);

			AwakeEx();
		}
	}


	void OnDestroy ()
	{
		OnDestroyEx ();

		if (_instance == this)
		{
			_instance = null;
		}
	}
	#endregion


	#region Virtual Methods
	protected virtual void AwakeEx () {}

	protected virtual void OnDestroyEx () {}
	#endregion

}