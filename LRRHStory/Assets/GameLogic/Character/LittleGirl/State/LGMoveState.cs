using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGMoveState : StateBase
{
    public LGMoveState(AbstractFsm fsm) : base(fsm)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("LGMoveState enter");
    }

    public override void OnDo()
    {
        Debug.Log("LGMoveState update");
    }

    public override void OnExit()
    {
        Debug.Log("LGMoveState exit");
    }
}
