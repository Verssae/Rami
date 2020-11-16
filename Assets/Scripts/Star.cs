using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    private GameObject plusPoint = null;

    [SerializeField]
    private GameObject boom = null;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<Score>().AcornPoint += 1;
            Instantiate(plusPoint, collision.transform.position, Quaternion.identity);
            GameObject boomObj = Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(boomObj, 0.5f);
            Destroy(gameObject);
        }
    }
}
