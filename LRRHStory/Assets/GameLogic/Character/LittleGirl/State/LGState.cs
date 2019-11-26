public enum LGStateEnum
{
    LGIdle = 0,
    LGMove = 1,
    LGJump = 2,
}

public enum LGAnimatorLayer
{
    BaseLayer = 0,
}

public static class LGAnimatorParms
{    
    //状态名
    public const string LG_MoveStateName = "MoveState";
    public const string LG_IdleStateName = "IdleState";
    public const string LG_JumpStateName = "JumpState";
    //参数名
    public const string LG_Int_CurState = "CurState";
    public const string LG_Bool_ToMove = "ToMove";
    public const string LG_Bool_ToIdel = "ToIdle";
    public const string LG_Bool_ToJump = "ToJump";  
    public const string LG_Float_MoveBlend = "MoveBlend";
}

public abstract class LGState : StateBase
{
    public LGFsm m_Fsm;

    public LGState(AbstractFsm fsm) : base(fsm)
    {
        m_Fsm = (LGFsm)fsm;
    }

    public override void OnEnter()
    {
        Reset();
    }

    public override void OnDo()
    {
    }

    public override void OnExit()
    {
      
    }

    private void Reset()
    {
        m_Fsm.m_LGCtrl.LGAnimator.SetBool(LGAnimatorParms.LG_Bool_ToIdel, false);
        m_Fsm.m_LGCtrl.LGAnimator.SetBool(LGAnimatorParms.LG_Bool_ToMove, false);
        m_Fsm.m_LGCtrl.LGAnimator.SetBool(LGAnimatorParms.LG_Bool_ToJump, false);
    }
}

