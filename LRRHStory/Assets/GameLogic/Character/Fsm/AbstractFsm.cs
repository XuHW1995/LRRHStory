public abstract class AbstractFsm
{
    public abstract void OnUpdate();
    public abstract void ChangeState(StateEnum newState);
    public abstract T GetState<T>(StateEnum stateEnum) where T : StateBase;
    public abstract void GoBackLastState();
}
