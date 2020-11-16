using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
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
            if (GetComponent<Movement>().isDevelopment)
            {
                Debug.Log($"Current Module: {collision.transform.parent.name}");
            }
            
            if (collision.transform.parent.GetComponent<ModuleInfo>().pass == false)
            {
                collision.transform.parent.GetComponent<ModuleInfo>().pass = true;
                if (_lastmodule.Count >= volume - 1)
                {
                    GameObject nextmodule = Instantiate(maps[Random.Range(0, maps.Length)], collision.transform.parent.parent);
                    GameObject nextPoint = Util.GetChildByName(collision.transform.parent.gameObject, "NextPoint");
                    nextmodule.transform.position = nextPoint.transform.position;
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
