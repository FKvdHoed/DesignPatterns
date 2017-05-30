public interface IStateMachine {
    void Update();
    void SetState(IState value);
}
