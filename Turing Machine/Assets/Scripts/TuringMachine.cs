using System.ComponentModel;
using System; 
using UnityEngine;
using System.Collections.Generic;

public class TuringMachine : MonoBehaviour
{
    StateMachine stateMachine; 

    string tape = "000000000000000000000"; // 21 characters long
    // List<string> tape = new List<string>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; // 21 long
    int headPos = 10; 

    public TuringMachine()
    {
        
    }

    private void Start()
    {
        List<State> busyBeaverStates = new List<State>()
        {
        new State(
            new List<int>(){1, 1}, 
            new List<char>(){'L', 'R'}, 
            new List<int>(){1, 2}),
        new State(
            new List<int>(){1, 1}, 
            new List<char>(){'R', 'L'}, 
            new List<int>(){0, 1}),
        new State(
            new List<int>(){1, 1}, 
            new List<char>(){'R', 'N'}, 
            new List<int>(){1, -1})
        };
        StateMachine busyBeaver = new StateMachine(busyBeaverStates); 

        stateMachine = busyBeaver; // this would preferably have a way to be changed around

        Run(); // this would be preferablly be ran with an input of some sort
    }

    // this would preferably have a way to increment and stop every so often
    // right now just a proof of concept
    public void Run()
    {
        while(stateMachine.Run(this) > 0)
        {
            Debug.Log(tape); 
        }
    }
    
    public int Read()
    {
        int number = Int32.Parse(tape.Substring(headPos, 1));  
        return number; 
    }

    public void Write(int number)
    {
        string stringNumber = number + ""; 
        tape = tape.Remove(headPos, 1).Insert(headPos, stringNumber); 
    }

    public void Move(char direction)
    {
        if(direction == 'L')
        {
            headPos --;// move left
        }
        else if(direction == 'R')
        {
            headPos ++;// move right
        }
    }
}
