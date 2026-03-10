using UnityEngine;
using System;
using System.Collections.Generic;

public class State
{
    public List<int> writeRule;
    public List<char> moveRule; 
    public List<int> changeStateRule; 

    // intialize 0 in the array with the response to a 0
    // intialize 1 in the array with the response to a 1

    // ie if i want to write a 1 whenever i see a 0 and vice versa i would:
    // writeRule = new Array<int>({1, 0}); 

    public State(List<int> writeRule, List<char> moveRule, List<int> changeStateRule)
    {
        this.writeRule = writeRule; 
        this.moveRule = moveRule; 
        this.changeStateRule = changeStateRule;
    }

    public State()
    {
        writeRule = new List<int>(); 
        moveRule = new List<char>(); 
        changeStateRule = new List<int>();
    }

    public int Write(int number)
    {
        int toWrite = writeRule[number]; 
        return toWrite; 
    }

    public char Move(int number)
    {
        char toMove = moveRule[number]; 
        return toMove; 
    }

    public int NextState(int number)
    {
        // return -1 if halt
        int nextState = changeStateRule[number];
        return nextState; 
    }
}