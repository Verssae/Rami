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
        Util.PlaySFX("Click");
        SceneManager.LoadScene("MainMenu");
        GameObject.Find("AudioController").GetComponent<BGMController>().TurnOff(1);
        GameObject.Find("AudioController").GetComponent<BGMController>().TurnOn(0);

    }

    public void RunInGame()
    {
        Util.PlaySFX("Click");
        SceneManager.LoadScene("InGame");
        GameObject.Find("AudioController").GetComponent<BGMController>().TurnOff(0);
        GameObject.Find("AudioController").GetComponent<BGMController>().TurnOn(1);

    }

    public void RunSetting()
    {
        Util.PlaySFX("Click");
        SceneManager.LoadScene("Setting");
        GameObject.Find("AudioController").GetComponent<BGMController>().TurnOff(1);
        GameObject.Find("AudioController").GetComponent<BGMController>().TurnOn(0);
    }

    public void DeletePopup()
    {
        Util.PlaySFX("Click");
        resetQuestion.gameObject.SetActive(true);
        
    }

    public void DeleteYes()
    {
        Util.PlaySFX("Click");
        Score.Delete();
        resetQuestion.gameObject.SetActive(false);
    }

    public void DeleteNo()
    {
        Util.PlaySFX("Click");
        resetQuestion.gameObject.SetActive(false);
    }

}
