using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public IState CurrentState { get; private set; }

    public StateMachine(IState _default)
    {
        CurrentState = _default;
    }

    public void SetState(IState _state)
    {
        if (CurrentState == _state) return;

        CurrentState.OperateExit();

        CurrentState = _state;

        CurrentState.OperateEnter();
    }

    public void DoOperateUpdate()
    {
        CurrentState.OperateUpdate();
    }
}
