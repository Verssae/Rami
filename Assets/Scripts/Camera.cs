using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0, player.position.y - distance, transform.position.z);
    }
}
