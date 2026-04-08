using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq; 

public static class TextReader
{

    public static List<State> Read(string text)
    {
        List<State> machineStates = new List<State>();
        // split the string into lines
        string[] lines = text.Split( new string[] { Environment.NewLine }, StringSplitOptions.None);
        int index = 0; 
        string currentLine = lines[index]; 
        
        /*
        state index
        if its write, move, or change state
        the instruction 
        */

        while (index < lines.Length)
        {
            int stateIndex = -1;
            List<int> writeInstruction = new List<int>(); 
            List<char> moveInstruction = new List<char>();
            List<int> changeStateInstruction = new List<int>();

            currentLine = lines[index]; 

            while (currentLine.Contains(":") && index < lines.Length)
            {
                currentLine = RemoveWhitespace(currentLine); 
                //Debug.Log(currentLine); 

                int colonPos = currentLine.IndexOf(":");
                int commaPos = 0; //currentLine.IndexOf(',');
                string instruction = currentLine.Substring(0, colonPos); // state, write, move. or changeState is everything before the colon
                int valueFor0 = 0; //= currentLine.Substring(colonPos, commaPos - colonPos); // value for zero is after colon, totalling the lenght of everything before the comma
                int valueFor1 = 0; //= currentLine.Substring(commaPos, currentLine.Length - commaPos); // value for one is after comma, all the way to the end of the string

                switch (instruction)
                {
                    case "state":
                        stateIndex = int.Parse(currentLine.Substring(colonPos+1, 1));
                        break; 
                    case "write":
                        commaPos = currentLine.IndexOf(',');
                        valueFor0 = int.Parse(currentLine.Substring(colonPos+1, 1)); // value for zero is after colon, totalling the lenght of everything before the comma
                        valueFor1 = int.Parse(currentLine.Substring(commaPos+1, 1)); // value for one is after comma, all the way to the end of the string
                        writeInstruction.Add(valueFor0); 
                        writeInstruction.Add(valueFor1);
                        break;
                    case "move":
                        commaPos = currentLine.IndexOf(',');
                        char charValueFor0 = char.Parse(currentLine.Substring(colonPos+1, 1)); // value for zero is after colon, totalling the lenght of everything before the comma
                        char charValueFor1 = char.Parse(currentLine.Substring(commaPos+1, 1)); // value for one is after comma, all the way to the end of the string
                        moveInstruction.Add(charValueFor0); 
                        moveInstruction.Add(charValueFor1);
                        break; 
                    case "changeState":
                        commaPos = currentLine.IndexOf(',');
                        valueFor0 = int.Parse(currentLine.Substring(colonPos+1, 1)); // value for zero is after colon, totalling the lenght of everything before the comma
                        valueFor1 = int.Parse(currentLine.Substring(commaPos+1)); // value for one is after comma, all the way to the end of the string
                        changeStateInstruction.Add(valueFor0); 
                        changeStateInstruction.Add(valueFor1);
                        break;
                }

                index++; 
                if(index < lines.Length) currentLine = lines[index]; 
            }
            //machineStates[stateIndex] = new State(writeInstruction, moveInstruction, changeStateInstruction); // create new machineState    
            if(stateIndex >= 0)
            {
                machineStates.Add(new State(writeInstruction, moveInstruction, changeStateInstruction)); 
                Debug.Log("State " + stateIndex + " just created"); 
            }
            else
            {
                index++; 
            }
            

            if(index < lines.Length) currentLine = lines[index]; 
        }
        Debug.Log("number of machine states: " + machineStates.Count); 
        return machineStates; 
    }

    public static string RemoveWhitespace(this string input)
    {      
        return new string(input
        .Where(c => !Char.IsWhiteSpace(c))
        .ToArray());
    }
}

