using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttack : IState
{
    public void OperateEnter()
    {
        Player.instance.GetComponentInChildren<Animator>().SetBool("Attack", true);
    }

    public void OperateExit()
    {
        Player.instance.GetComponentInChildren<Animator>().SetBool("Attack", false);
    }

    public void OperateUpdate()
    {

    }
}
