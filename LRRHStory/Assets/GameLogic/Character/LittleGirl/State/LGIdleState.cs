using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGIdleState : StateBase
{
    private LGFsm m_Fsm;
    public LGIdleState(AbstractFsm fsm) : base(fsm)
    {
        m_Fsm = (LGFsm)fsm;
    }

    public override void OnEnter()
    {
        m_Fsm.m_LGCtrl.ResetParams();
        m_Fsm.m_LGCtrl.LGAnimator.SetBool("ToIdle", true);
        m_Fsm.m_LGCtrl.LGAnimator.SetInteger("CurState", 0);
        Debug.Log("LGidle enter");
    }

    public override void OnDo()
    {
        
    }

    public override void OnExit()
    {
        m_Fsm.m_LGCtrl.LGAnimator.SetBool("ToIdle", false);
        Debug.Log("LGidle exit");
    }
}
