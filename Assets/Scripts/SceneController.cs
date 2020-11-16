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
        GameObject.Find("AudioController").GetComponent<BGMController>().TurnOff(1);
        GameObject.Find("AudioController").GetComponent<BGMController>().TurnOn(0);

    }

    public void RunInGame()
    {
        SceneManager.LoadScene("InGame");
        GameObject.Find("AudioController").GetComponent<BGMController>().TurnOff(0);
        GameObject.Find("AudioController").GetComponent<BGMController>().TurnOn(1);

    }

    public void RunSetting()
    {
        SceneManager.LoadScene("Setting");
        GameObject.Find("AudioController").GetComponent<BGMController>().TurnOff(1);
        GameObject.Find("AudioController").GetComponent<BGMController>().TurnOn(0);
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
