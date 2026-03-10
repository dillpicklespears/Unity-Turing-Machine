using System.ComponentModel;
using UnityEngine;
using System.Collections.Generic;

public class TuringMachine : MonoBehaviour
{
    StateMachine stateMachine; 

    public TuringMachine()
    {
        
    }

    private void Start()
    {
        List<State> busyBeaverStates = new List<State>(); 
        State busyBeaverState0 = new State(
            new List<int>(){1, 1}, 
            new List<char>(){'L', 'R'}, 
            new List<int>(){1, 2}); 
        State busyBeaverState1 = new State(
            new List<int>(){1, 1}, 
            new List<char>(){'R', 'L'}, 
            new List<int>(){0, 1}); 
        State busyBeaverState2 = new State(
            new List<int>(){1, 1}, 
            new List<char>(){'R', 'N'}, 
            new List<int>(){1, -1}); 
        StateMachine busyBeaver = new StateMachine(this, busyBeaverStates); 
    }
    
    public int Read()
    {
        int number = 0; 
        // read number
        return number; 
    }

    public void Write(int number)
    {
        // write that number 
    }

    public void Move(char direction)
    {
        if(direction == 'L')
        {
            // move left
        }
        else if(direction == 'R')
        {
            // move right
        }
    }
}
