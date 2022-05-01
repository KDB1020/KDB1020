using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRun : IState
{
    float speed = 4.0f;

    public void OperateEnter()
    {

    }

    public void OperateExit()
    {
        Player.instance.GetComponentInChildren<Animator>().SetBool("Run", false);
    }

    public void OperateUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Player.instance.GetComponentInChildren<Animator>().SetFloat("DirX", inputX);
        Player.instance.GetComponentInChildren<Animator>().SetFloat("DirY", inputZ);

        Player.instance.GetComponentInChildren<Animator>().SetBool("Run", true);

        Player.instance.gameObject.transform.Translate(inputX * speed * Time.deltaTime, 0, inputZ * speed * Time.deltaTime);
    }
}
