using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private Image resetQuestion = null;
    // Start is called before the first frame update
    public void RunMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RunInGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void RunSetting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void DeletePopup()
    {
        resetQuestion.gameObject.SetActive(true);
        
    }

    public void DeleteYes()
    {
        Score.Delete();
        resetQuestion.gameObject.SetActive(false);
    }

    public void DeleteNo()
    {
        resetQuestion.gameObject.SetActive(false);
    }

}
