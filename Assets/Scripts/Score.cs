using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int AcornPoint { get; set; } = 0;

    [SerializeField]
    private Text score = null;

    [SerializeField]
    private Transform player = null;

    [SerializeField]
    private int biasY = 0;

    [SerializeField]
    private int acornCoef = 20;

    [SerializeField]
    private Text bestScore = null;

    [SerializeField]
    private Image newScore = null;


    private int travel = 0;

    private int curScore = 0;

    public void Save()
    {
        PlayerPrefs.SetInt("BestScore", curScore);
    }

    public int Load()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            return PlayerPrefs.GetInt("BestScore");
        } 
        else
        {
            return 0;
        }
    }

    public void GameOver()
    {
        if (curScore > Load())
        {
            Save();
        
        }
        bestScore.text = Load().ToString();
    }

    public static void Delete()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
    }


    private void Update()
    {
        travel = (int)(-player.position.y * 2) + biasY;
        curScore = travel + AcornPoint * acornCoef;
        score.text = (curScore).ToString();
        if (curScore > Load())
        {
            score.color = Color.white;
            newScore.gameObject.SetActive(true);
        }
    }
}