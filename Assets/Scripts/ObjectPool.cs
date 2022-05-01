using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInfo
{
    public string objectName;
    public GameObject prefab;
    public int count;
}

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] ObjectInfo[] objectInfos = null;

    [SerializeField] Transform poolParent;

    public List<Queue<GameObject>> objectPoolList = new List<Queue<GameObject>>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    private void Start()
    {
        ObjectPoolState();
    }

    void ObjectPoolState()
    {
        if(objectInfos != null)
        {
            for (int i = 0; i < objectInfos.Length; i++)
            {
                objectPoolList.Add(InsertQueue(objectInfos[i]));
            }
        }
    }

    Queue<GameObject> InsertQueue(ObjectInfo _prefab)
    {
        Queue<GameObject> queue = new Queue<GameObject>();

        for (int i = 0; i < _prefab.count; i++)
        {
            GameObject obj = Instantiate(_prefab.prefab) as GameObject;
            obj.SetActive(false);
            obj.transform.SetParent(poolParent);
            queue.Enqueue(obj);
        }

        return queue;
    }
}
