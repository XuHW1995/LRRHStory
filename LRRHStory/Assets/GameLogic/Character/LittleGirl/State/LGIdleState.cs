using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGIdleState : StateBase
{
    public LGIdleState(AbstractFsm fsm) : base(fsm)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("LGidle enter");
    }

    public override void OnDo()
    {
        //Debug.Log("LGidle update");
    }

    public override void OnExit()
    {
        Debug.Log("LGidle exit");
    }
}
