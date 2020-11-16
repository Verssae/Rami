using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RunInGame()
    {
        SceneManager.LoadScene("InGame");
    }
}
