using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{
    public static BGMController instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Debug.Log("Start");

        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Setting")
        {
            TurnOn(0);
            TurnOff(1);

        }

        if (SceneManager.GetActiveScene().name == "InGame")
        {
            TurnOff(0);
            TurnOn(1);
        }
    }

    public void TurnOn(int index)
    {
        AudioSource bgm = transform.GetChild(index).GetComponent<AudioSource>();
        if (!bgm.isPlaying)
        {
            bgm.Play();
        }
    }

    public void TurnOff(int index)
    {
        AudioSource bgm = transform.GetChild(index).GetComponent<AudioSource>();
        if (bgm.isPlaying)
        {
            bgm.Stop();
        }
    }







}
