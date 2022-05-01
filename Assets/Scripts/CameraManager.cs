using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(target.transform.position.x + offsetX, target.transform.position.y + offsetY, target.transform.position.z + offsetZ);
        transform.position = pos;
    }
}
