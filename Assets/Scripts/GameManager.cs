using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int StarPoint { get; set; } = 0;
    public bool End { get; set; } = false;

    public Text acon;
    public GameObject gameOver;
    public GameObject gamePause;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Resolution[] resolutions = Screen.resolutions;
        foreach (Resolution res in resolutions)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        acon.text = $"도토리 {StarPoint}개";
        if (End)
        {

            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0.5f;
            GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        gamePause.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        gamePause.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameObject.Find("SceneController").GetComponent<SceneController>().RunInGame();

    }



}


