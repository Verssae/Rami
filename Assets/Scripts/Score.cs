using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text countText;
    private int travel;
    public Transform player;

    public int biasY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        travel = (int)(-player.position.y * 2) + biasY;
        countText.text = travel.ToString() + "m";
    }
}