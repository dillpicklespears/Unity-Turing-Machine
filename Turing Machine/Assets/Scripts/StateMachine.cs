using UnityEngine;
using System.Collections.Generic;
using System; 

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
        
        turingMachine.Write(state.Write(number)); 
        
        turingMachine.Move(state.Move(number)); 
        
        int nextState = state.NextState(number); 
        if(nextState >= 0) // will be negative to halt
        {
            state = states[state.NextState(number)]; 
            return 1; 
        }
        return -1;
    }
}