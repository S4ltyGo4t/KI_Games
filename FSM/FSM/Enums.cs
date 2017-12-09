using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
