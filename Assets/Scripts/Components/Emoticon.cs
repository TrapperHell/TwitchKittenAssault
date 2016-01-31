using System.Collections;
using UnityEngine;

public class Emoticon : MonoBehaviour
{

    [SerializeField]
    private float _magnitude = 0.2f;
    [SerializeField]
    private float _dampAfterDuration = 5.0f;
    [SerializeField]
    private Sprite[] _emoticons;
    [SerializeField]
    private string[] _emoticonNames;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    private int _selectedEmoticon;
    private float _startTime;



    // Use this for initialization
    void Start()
    {
        _selectedEmoticon = 0;

    }

    void OnEnable()
    {
        PlayShake();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void NewEmoticon()
    {
        _startTime = Time.time;
        _selectedEmoticon = Random.Range(0, _emoticons.Length);

        _spriteRenderer.sprite = _emoticons[_selectedEmoticon];
    }

    public string CurrentEmoticon()
    {
        return _emoticonNames[_selectedEmoticon];
    }

    // -------------------------------------------------------------------------
    public void PlayShake()
    {

        StopAllCoroutines();
        StartCoroutine("Shake");
    }


    // -------------------------------------------------------------------------
    IEnumerator Shake()
    {

        float elapsed = 0.0f;

        Vector3 originalPos = transform.position;

        while (Time.time <= _startTime + GameController.Instance.VoteTime)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / _dampAfterDuration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
            damper = 1;
            // map noise to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= _magnitude * damper;
            y *= _magnitude * damper;

            transform.position = new Vector3(x, y, originalPos.z);

            yield return null;
        }

        transform.position = originalPos;
        GameController.Instance.EndVote();
        gameObject.SetActive(false);
    }
}