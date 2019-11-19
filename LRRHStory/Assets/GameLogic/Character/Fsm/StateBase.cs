using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase
{
    public AbstractFsm CurFsm { get; private set; }

    public abstract void OnEnter();
    public abstract void OnDo();
    public abstract void OnExit();

    public StateBase(AbstractFsm fsm)
    {
        CurFsm = fsm;
    }
}