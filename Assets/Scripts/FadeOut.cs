using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField]
    private float fadeTime = 1f;

    private float _time = 0f;

    private void Start()
    {
        //ResetAnim();
    }


    // Update is called once per frame
    private void Update()
    {
        if (_time < fadeTime)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f - _time / fadeTime);
        }
        else
        {
            _time = 0;
            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
        _time += Time.deltaTime;
    }

    public void ResetAnim()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        gameObject.SetActive(true);
    }
}
