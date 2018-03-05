namespace FSM
{
    public enum ProcessState
    {
        Idle,
        MovingForward,
        MovingBackward,
        MovingLeft,
        MovingRight,
        Terminated
    } 

    public enum Command
    {
        W,
        A,
        S,
        D,
        Exit
    }
}
