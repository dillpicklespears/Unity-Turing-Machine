using UnityEngine;
using System;
using System.Collections.Generic;

/*
state: 0
write: 1,1
move: L, R
changeState: 1, 2

state: 1
write: 1, 1
move: R, L
changeState: 0, 1

state: 2
write: 1, 1
move: R, N
changeState: 1, -1



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

*/


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

    public string toString()
    {
        return "write:" + writeRule[0] + "," + writeRule[1] + "\n" +
        "move:" + moveRule[0] + "," + moveRule[1] + "\n" + 
        "changeState:" + changeStateRule[0] + "," + changeStateRule[1] + "\n";
    }
}