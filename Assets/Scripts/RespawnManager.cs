using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject bound;
    BoxCollider coll;

    float rockTimer = 0f;
    float branchTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        coll = bound.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        rockTimer += Time.deltaTime;
        branchTimer += Time.deltaTime;

        RespawnRock();
        RespawnBranch();
    }

    void RespawnRock()
    {
        if (rockTimer >= 3)
        {
            GameObject rock = ObjectPool.instance.objectPoolList[0].Dequeue();
            rock.SetActive(true);
            rock.transform.position = RandomPosition();
            rockTimer = 0;
        }
    }

    void RespawnBranch()
    {
        if(branchTimer >= 1)
        {
            GameObject branch = ObjectPool.instance.objectPoolList[1].Dequeue();
            branch.SetActive(true);
            branch.transform.position = RandomPosition();
            branchTimer = 0;
        }
    }

    Vector3 RandomPosition()
    {
        Vector3 pos = bound.transform.position;
        float rangeX = coll.bounds.size.x;
        float rangeZ = coll.bounds.size.z;

        rangeX = Random.Range((rangeX / 2) * -1, rangeX / 2);
        rangeZ = Random.Range((rangeZ / 2) * -1, rangeZ / 2);

        Vector3 randomPos = new Vector3(rangeX, -0.6f, rangeZ);

        Vector3 respawnPos = pos + randomPos;
        return respawnPos;
    }
}
