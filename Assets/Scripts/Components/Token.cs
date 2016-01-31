using System;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Token : MonoBehaviour, IPoolable
{
	#region Private Properties

    [SerializeField]
    private string _tokenTag = "Token";
    [SerializeField]
    private string _baseTag = "Base";
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private TextMesh _textMesh;
	private int _strength;
	private Team _sourceTeam;
    private Vector3 _originalScale;

	#endregion

	#region Accessors

	public int Strength
	{
		get
		{
			return _strength;
		}
		private set
		{
			_strength = value;

            SetScale();
		}
	}

	public Team SourceTeam
	{
		get
		{
			return _sourceTeam;
		}
		private set
		{
			_sourceTeam = value;
		}
	}

	#endregion

	#region Methods

    void SetScale()
    {
        if (this.Strength > 1)
    {
            float scaleAdd = this.Strength / 20f;
            scaleAdd = Math.Min(1, scaleAdd);
            transform.localScale = new Vector3(this._originalScale.x + scaleAdd, this._originalScale.y + scaleAdd, this._originalScale.z);
	}
        else
            transform.localScale = this._originalScale;
    }

	void OnTriggerEnter2D(Collider2D collider)
	{
		/*
			ASSUMPTION:
			When 2 tokens collide, we can assume that either one or both will be destroyed.
			We can use this assumption to resolve the collision in just one token (since it will normally be triggered in both)
		*/

		if (string.Equals(collider.tag.ToLower(), _tokenTag.ToLower()))
		{
			Token other = collider.GetComponent<Token>();
			if (other != null)
			{
				if (_sourceTeam != other.SourceTeam)
				{
					int thisStrength = Strength;
					int otherStrength = other.Strength;

					if (thisStrength >= otherStrength)
					{
						//See assumption above
						other.GetHit(thisStrength);
						GetHit(otherStrength);
						SoundManager.Instance.PlayRandomGenericMeow();
					}
				}
			}
		}

		if (string.Equals(collider.tag.ToLower(), _baseTag.ToLower()))
		{
			Team t = collider.GetComponent<Team>();
			if (t != null)
			{
				if (t != _sourceTeam)
				{
					if (t.Health <= 0)
					{
						int alive = 0;
						List<Team> ts = TeamManager.Instance.GetTeams();

						foreach (Team tx in ts)
						{
							if (tx.Health > 0)
							{
								alive++;
							
								if ((tx != t) && (tx != _sourceTeam))
								{
									WaypointControl.TokenMoveManager.Instance.MoveToken(gameObject, t.Name, tx.Name);
								}
							}
						}

						if (alive <= 1)
						{
							Time.timeScale = 0;
						}
					}
					else
					{
						SoundManager.Instance.PlayRandomGenericMeow();

					t.Hit(Strength);

                    Strength = 0; //Just to be safe
					PoolManager.Instance.TokenPool.Release(this);
				}
			}
		}
	}
	}

	private void GetHit(int opposingStrength)
	{
        Strength -= opposingStrength;
        _textMesh.text = Strength.ToString();

        if (Strength <= 0)
		{
			PoolManager.Instance.TokenPool.Release(this);
		}
	}

	#region IPoolable

	public void Consume(IPoolData _data)
	{
		TokenPoolData data = (TokenPoolData)_data;

        this._originalScale = transform.localScale;
		_strength = data.Strength;
        SetScale();

		_textMesh.text = data.Strength.ToString();
		_sourceTeam = data.SourceTeam;
		_spriteRenderer.color = data.SourceTeam.TeamColour;
		gameObject.SetActive(true);
		transform.SetParent(data.ParentTransform, false);
	}

	public void Release()
	{
		gameObject.SetActive(false);
	}

	#endregion

	#endregion
}
