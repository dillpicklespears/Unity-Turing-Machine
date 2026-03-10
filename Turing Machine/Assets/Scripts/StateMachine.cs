using UnityEngine;
using System.Collections.Generic;
using System; 

public class StateMachine
{
    public State state; 
    public List<State> states; 
    public TuringMachine turingMachine; 

    public StateMachine(TuringMachine turingMachine, List<State> states)
    {
        this.states = states; 
        this.state = states[0];
        this.turingMachine = turingMachine; 
    }

    public int Run()
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