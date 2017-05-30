public interface IState {
    bool Enter();
    bool Exit();
    void Update();
}