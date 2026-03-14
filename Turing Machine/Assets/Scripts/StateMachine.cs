using System.Collections.Generic;

public class StateMachine
{
    public State state;
    public List<State> states;

    public StateMachine(List<State> states)
    {
        this.states = states;
        this.state = states[0];
    }

    public int Run(TuringMachine turingMachine)
    {
        int number = turingMachine.Read();

        int toWrite = state.Write(number);
        char toMove = state.Move(number);
        int nextState = state.NextState(number);

        UnityEngine.Debug.Log($"Read {number}, Write {toWrite}, Move {toMove}, NextState {nextState}");

        turingMachine.Write(toWrite);
        turingMachine.Move(toMove);

        if (nextState >= 0)
        {
            state = states[nextState];
            return 1;
        }

        return -1;
    }
}