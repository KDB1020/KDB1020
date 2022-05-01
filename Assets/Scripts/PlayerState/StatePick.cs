using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePick : IState
{
    public void OperateEnter()
    {
        Player.instance.CheckItem();
    }

    public void OperateExit()
    {

    }

    public void OperateUpdate()
    {
        Player.instance.CheckItem();
        Player.instance.CanPickUp();
    }
}
