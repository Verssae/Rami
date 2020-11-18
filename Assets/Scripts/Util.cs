using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Util
{

    public static GameObject GetChildByName(GameObject obj, string name)
    {
        Transform child = obj.transform.Find(name);
        if (child != null)
        {
            return child.gameObject;
        }
        else
        {
            return null;
        }
    }

    public static void PlaySFX(string name)
    {
        AudioSource sfx = GameObject.Find("SFX").transform.Find(name).GetComponent<AudioSource>();
        
        
         sfx.Play();
        
    }
}


