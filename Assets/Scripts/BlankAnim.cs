using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlankAnim : MonoBehaviour
{
    [SerializeField]
    private float time = 1;
    private float _time = 0;

    private void Update()
    {
        if (_time < time * 0.5f)
        {

            GetComponent<Image>().color = new Color(1, 1, 1, 1 - _time);
        }
        else
        {
            GetComponent<Image>().color = new Color(1, 1, 1, _time);
            if (_time > time)
            {
                _time = 0;
            }
        }

        _time += Time.deltaTime;
    }
}
