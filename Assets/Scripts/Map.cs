using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("로드 할 맵 모듈 모음")]

    [SerializeField]
    private GameObject[] maps = null;

    [Header("시작 시 추가한 맵 모듈 수")]

    [SerializeField]
    private int volume = 0;

    private readonly Queue<GameObject> _lastmodule = new Queue<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Start"))
        {
            if (collision.transform.parent.GetComponent<ModuleInfo>().pass == false)
            {
                collision.transform.parent.GetComponent<ModuleInfo>().pass = true;
                if (_lastmodule.Count >= volume - 1)
                {
                    GameObject nextmodule = Instantiate(maps[Random.Range(0, maps.Length)], collision.transform.parent.parent);
                    GameObject newpoint = collision.transform.parent.GetChild(5).gameObject;
                    Debug.Log(newpoint.name);
                    nextmodule.transform.position = newpoint.transform.position;
                    //nextmodule.transform.GetChild(0).tag = "Start";
                    //nextmodule.transform.GetChild(1).tag = "LTree";
                    //nextmodule.transform.GetChild(2).tag = "RTree";
                    //nextmodule.transform.GetChild(3).tag = "Obstacle";
                    //nextmodule.transform.GetChild(4).tag = "Star";
                }
                if (_lastmodule.Count >= volume)
                {
                    Destroy(_lastmodule.Dequeue());
                }
                _lastmodule.Enqueue(collision.transform.parent.gameObject);
            }
        }
    }



}
