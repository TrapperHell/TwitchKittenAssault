using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (AudioSource))]
public class SoundManager : MonoSingleton <SoundManager> {

	#region Constants

	#endregion

	#region Public Properties

	#endregion

	#region Private Properties
	[SerializeField] private List<AudioClip> _genericMeows;
	[SerializeField] private List<AudioClip> _angryMeows;
	[SerializeField] private List<AudioClip> _sadMeows;

	private AudioSource _audioSource;
	#endregion

	#region Accessors

	#endregion

	protected override void AwakeEx ()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void PlayNewPlayer()
	{
		_audioSource.PlayOneShot(_genericMeows[Random.Range(0, _genericMeows.Count)]);
	}

	public void PlayBaseDie()
	{
		_audioSource.PlayOneShot(_sadMeows[Random.Range(0, _sadMeows.Count)]);
	}

	public void PlayTokenHit()
	{
		_audioSource.PlayOneShot(_angryMeows[Random.Range(0, _angryMeows.Count)]);
	}
}
