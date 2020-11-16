using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float distance;
    // Start is called before the first frame update
    void Awake()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        ////5 : 16 = x : 18; x = 18 * 5 / 16
        //Debug.Log(Screen.height);

        float scaleHeight = ((float)Screen.width / Screen.height) / ((float)9 / 16);
        float scaleWidth = 1f / scaleHeight;

        if (scaleHeight < 1)
        {
            rect.height = scaleHeight;
            rect.y = (1f - scaleHeight) / 2f;
        }
        else
        {
            rect.width = scaleWidth;
            rect.x = (1f - scaleWidth) / 2f;
        }
        camera.rect = rect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player)
        {
            transform.position = new Vector3(0, player.position.y - distance, transform.position.z);
        }
        
    }
}
