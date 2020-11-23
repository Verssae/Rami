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

    private bool popuped = false;

    public void PauseGame()
    {
        Util.PlaySFX("Click");
        Time.timeScale = 0f;
        gamePause.SetActive(true);
        popuped = true;
    }

    public void ResumeGame()
    {
        Util.PlaySFX("Click");
        gamePause.SetActive(false);
        Time.timeScale = 1f;
        popuped = false;
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
            popuped = true;

        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home))
            {
                PauseGame();
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                if (popuped)
                {
                    if (gameOver.activeSelf)
                    {
                        sceneController.RunMainMenu();
                    }

                    if (gamePause.activeSelf)
                    {
                        ResumeGame();
                    }
                    
                }
                else
                {
                    PauseGame();
                }
                
            }
            else if (Input.GetKey(KeyCode.Menu))
            {
                //menu button
            }
        }


    }





}


