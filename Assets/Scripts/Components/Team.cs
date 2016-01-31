using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Transform))]
public class Team : MonoBehaviour {

	#region Public Properties
	public Text PlayerNamesText;
	#endregion

	#region Private Properties
	[SerializeField] private string _teamName;
	[SerializeField] private Color _teamColour;
	[SerializeField] private Image _healthBar;
	[SerializeField] private GameObject _castle;
    [SerializeField] private Color _hitColor;
    [SerializeField] private Color _healColor;

    private List<string> _players;
	private Transform _transform;
	private int _health;

	private int _votes;

    
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

	public int PlayerCount
	{
		get
		{
			return _players.Count;
		}
	}

	public Transform TeamBase
	{
		get
		{
			return _transform;
		}
	}

	public Color TeamColour
	{
		get
		{
			return _teamColour;
		}
	}

	public int Health
	{
		get
		{
			return _health;
		}
	}

	public int Votes
	{
		get
		{
			return _votes;
		}
	}
	#endregion

	#region Methods
	void Awake()
	{
		_transform = GetComponent<Transform>();
		_players = new List<string>();
		_health = TeamManager.Instance.StartingHealth;
	}

	void Start()
	{
		
	}

	public List<string> GetPlayers()
	{
		return _players;
	}

	public void RegisterPlayer(string playerName)
	{
		if (_players.Contains(playerName) == false)
		{
			_players.Add(playerName);

			List<Lane> lanes = LaneManager.Instance.GetTeamLanes(this);

			GameController.Instance.GoToLane(playerName, lanes[Random.Range(0, lanes.Count)].LaneName);

			_players.Sort();
			if (PlayerNamesText != null)
				PlayerNamesText.text = string.Join(", ", this._players.ToArray());


			SoundManager.Instance.PlayNewPlayer();
		}
	}

	public bool HasPlayer(string playerName)
	{
		return _players.Contains(playerName);
	}

	public void Hit(int tokenStrength)
	{
		_health -= tokenStrength;

		UpdateHealthBar();

		if (_health <= 0)
		{
			SoundManager.Instance.PlayBaseDie();
			_castle.SetActive(false);
		} else
        {
            StartCoroutine("FlashHit");
        }
	}

    public void Heal(int healStrength)
    {
        if (_health != TeamManager.Instance.StartingHealth)
        {
            StartCoroutine("FlashHeal");
            SoundManager.Instance.PlayBaseHeal();

            _health += healStrength;

            // If Health exceedeed Starting Health (Max), then set to that value
            if (_health > TeamManager.Instance.StartingHealth)
            {
                _health = TeamManager.Instance.StartingHealth;
            }

			UpdateHealthBar();
        }
    }

	public void UpdateHealthBar()
	{
		_healthBar.rectTransform.sizeDelta = new Vector2((_health/ TeamManager.Instance.StartingHealth) * 100.0f, _healthBar.rectTransform.sizeDelta.y);
	}

    public void KillOtherTokens()
    {
        List<Token> tokensInUse = PoolManager.Instance.TokenPool.InUse;
        foreach (Token token in tokensInUse)
        {
            if (token.SourceTeam != this)
            {
                token.Release();
            }
        }
    }

	public void ClearVotes()
	{
		_votes = 0;
	}

	public void Vote()
	{
		_votes++;
	}

    System.Collections.IEnumerator FlashHeal()
    {
        SpriteRenderer castleSprite = _castle.GetComponent<SpriteRenderer>();
        Color originalColor = castleSprite.color;
        float timeFade = 0;

        while (true)
        {
            // Heal Color Fade In
            if (_healColor == castleSprite.color)
            {
                break;
            }
            castleSprite.color = Color.Lerp(Color.white, _healColor, timeFade);
            timeFade += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        timeFade = 0;
        while (true)
        {
            // Heal Color Fade Out
            if (Color.white == castleSprite.color)
            {
                break;
            }
            castleSprite.color = Color.Lerp(_healColor, Color.white, timeFade);
            timeFade += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

        System.Collections.IEnumerator FlashHit()
    {
        SpriteRenderer castleSprite = _castle.GetComponent<SpriteRenderer>();
        castleSprite.color = _hitColor;
        yield return new WaitForSeconds(.1f);
        castleSprite.color = Color.white; 
    }
	#endregion


}