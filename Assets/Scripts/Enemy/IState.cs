public interface IState {
    void Handle(IStateContext context);
}