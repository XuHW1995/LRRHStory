namespace XFramework
{
    public abstract class GameMgr<T> : SingleTon<T>, IGameMgr where T:new()
    {
        public virtual void Init(){ }
        public virtual void Start(){ }
        public virtual void EnterGame(){ }
        public virtual void Update() { }
        public virtual void Destroy() { }
    }

    public interface IGameMgr
    {
        void Init();
        void Start();
        void EnterGame();
        void Update();
        void Destroy();
    }
}
