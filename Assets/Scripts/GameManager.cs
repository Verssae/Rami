using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int StarPoint { get; set; } = 0;
    public bool End { get; set; } = false;
    public Text UI;
    public Button restart;
    public Button resume;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        UI.text = $"STAR: {StarPoint}";
        if (End)
        {

            restart.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        restart.gameObject.SetActive(true);
        resume.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        resume.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}


