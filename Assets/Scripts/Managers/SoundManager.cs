using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoSingleton<SoundManager>
{
    #region Constants

    #endregion

    #region Public Properties

    #endregion

    #region Private Properties
    [SerializeField]
    private List<AudioClip> _genericMeows;
    [SerializeField]
    private List<AudioClip> _angryMeows;
    [SerializeField]
    private List<AudioClip> _sadMeows;
    [SerializeField]
    private List<AudioClip> _healMeow;
	[SerializeField] AudioClip _emoticonYell;

    private AudioSource _audioSource;
    #endregion

    #region Accessors

    #endregion

    protected override void AwakeEx()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayNewPlayer()
    {
        if (_genericMeows.Any())
            _audioSource.PlayOneShot(_genericMeows[Random.Range(0, _genericMeows.Count)]);
    }

    public void PlayBaseDie()
    {
        if (_sadMeows.Any())
            _audioSource.PlayOneShot(_sadMeows[Random.Range(0, _sadMeows.Count)]);
    }

    public void PlayTokenHit()
    {
        if (_angryMeows.Any())
            _audioSource.PlayOneShot(_angryMeows[Random.Range(0, _angryMeows.Count)]);
    }

	public void PlayBaseHeal()
	{
		if (_healMeow.Any())
			_audioSource.PlayOneShot(_healMeow[Random.Range(0, _healMeow.Count)]);
	}


	public void PlayEmoticonYell()
	{
		if (_emoticonYell != null)
			_audioSource.PlayOneShot(_emoticonYell);
	}
}