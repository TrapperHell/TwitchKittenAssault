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
	[SerializeField] private AudioClip _newPlayerMeow;
	[SerializeField] private AudioClip _baseDieMeow;

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
		_audioSource.PlayOneShot(_newPlayerMeow);
	}

	public void PlayBaseDie()
	{
		_audioSource.PlayOneShot(_baseDieMeow);
	}

	public void PlayRandomGenericMeow()
	{
		_audioSource.PlayOneShot(_genericMeows[Random.Range(0, _genericMeows.Count)]);
	}
}
