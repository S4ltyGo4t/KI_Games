using System;
using System.Collections.Generic;

namespace FSM
{
    public class Process
    {
        Dictionary<StateTransition, ProcessState> transitions;
        public ProcessState CurrentState { get; private set; }

        public Process()
        {
            CurrentState = ProcessState.Idle;
            transitions = new Dictionary<StateTransition, ProcessState>()
            {
                { new StateTransition(ProcessState.Idle, Command.Exit), ProcessState.Terminated },
                { new StateTransition(ProcessState.Idle, Command.W), ProcessState.MovingForward },
                { new StateTransition(ProcessState.Idle, Command.A), ProcessState.MovingLeft },
                { new StateTransition(ProcessState.Idle, Command.S), ProcessState.MovingBackward },
                { new StateTransition(ProcessState.Idle, Command.D), ProcessState.MovingRight },
                { new StateTransition(ProcessState.MovingForward, Command.Exit), ProcessState.Terminated },
                { new StateTransition(ProcessState.MovingForward, Command.W), ProcessState.Idle },
                { new StateTransition(ProcessState.MovingBackward, Command.Exit), ProcessState.Terminated },
                { new StateTransition(ProcessState.MovingBackward, Command.S), ProcessState.Idle },
                { new StateTransition(ProcessState.MovingLeft, Command.Exit), ProcessState.Terminated },
                { new StateTransition(ProcessState.MovingLeft, Command.A), ProcessState.Idle },
                { new StateTransition(ProcessState.MovingRight, Command.Exit), ProcessState.Terminated },
                { new StateTransition(ProcessState.MovingRight, Command.D), ProcessState.Idle }
            };
        }

        public ProcessState GetNext(Command command)
        {
            StateTransition transition = new StateTransition(CurrentState, command);
            ProcessState nextState;
            if (!transitions.TryGetValue(transition, out nextState))
            {
                //Red warning on Console keep old state
                // also could throw new Exception("Invalid transition: " + CurrentState + " -> " + command);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input cant find Transition!\n");
                Console.ForegroundColor = ConsoleColor.White;
                return CurrentState;
            }
            return nextState;
        }

        public ProcessState MoveNext(Command command)
        {
            CurrentState = GetNext(command);
            return CurrentState;
        }
    }
}
