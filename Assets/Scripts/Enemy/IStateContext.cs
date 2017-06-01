public interface IStateContext {
    void Request();
    void SetState(IState value);
}
