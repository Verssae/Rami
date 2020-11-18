using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    
    public bool End { get; set; } = false;

    [SerializeField]
    private GameObject gameOver = null;

    [SerializeField]
    private GameObject gamePause = null;

    [SerializeField]
    private SceneController sceneController = null;

    public void PauseGame()
    {
        Util.PlaySFX("Click");
        Time.timeScale = 0f;
        gamePause.SetActive(true);
    }

    public void ResumeGame()
    {
        Util.PlaySFX("Click");
        gamePause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Util.PlaySFX("Click");
        Time.timeScale = 1f;
        sceneController.RunInGame();
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }


    private void Update()
    {
        
        if (End)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0.5f;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Score>().GameOver();
            
        }
    }





}


