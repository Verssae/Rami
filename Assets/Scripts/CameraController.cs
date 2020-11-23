using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    [SerializeField] 
    private Transform player = null;

    [SerializeField] 
    private float distance = 0;

    private void Awake()
    {
        Camera camera = GetComponent<Camera>();
        float ratio = Screen.height / (Screen.width / 9f);
        float cameraSize = ratio * 5f / 16f;
        camera.orthographicSize = cameraSize;
    }

    private void LateUpdate()
    {
        if (player)
        {
            transform.position = new Vector3(0, player.position.y - distance, transform.position.z);
        }
        
    }
}
