using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusPoint : MonoBehaviour
{
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 velocity = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity;
        dir = new Vector3(velocity.x, velocity.y, -1);
        //dir = new Vector3(Random.Range(-1f, 0f), Random.Range(-1f,0f), -1).normalized;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }

    public void ResetAnim()
    {
        transform.position = Vector3.zero;
        dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -1).normalized;
    }
}
