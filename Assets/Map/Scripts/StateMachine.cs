namespace StateMachine
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }
        public State NextState { get; private set; }
        public State PrevState { get; private set; }

        public void ChangeState(ref State newState)
        {
            NextState = newState;
            PrevState = CurrentState;
            CurrentState?.Exit();
            CurrentState = newState;
            newState.Enter();
        }
    }
}

