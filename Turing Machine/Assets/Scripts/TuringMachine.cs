using System;
using UnityEngine;
using System.Collections.Generic;

public class TuringMachine : MonoBehaviour
{
    StateMachine stateMachine;
    public TapeRenderer tapeRenderer;
    public TapeHead head;

    [SerializeField] private TuringWriteVFX writeVFX;

    string tape = "000000000000000000000";
    int headPos = 10;

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

        stateMachine = new StateMachine(busyBeaverStates);
        SyncTapeToVisuals();
        if (head != null)
            head.MoveTo(headPos);
        Run();
    }

    public void Run()
    {
        StartCoroutine(RunRoutine());
    }

    private System.Collections.IEnumerator RunRoutine()
    {
        int result = 1;

        while (result > 0)
        {
            result = stateMachine.Run(this);
            Debug.Log($"Tape: {tape} | Head: {headPos}");
            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("Machine halted.");
    }

    public int Read()
    {
        if (headPos < 0 || headPos >= tape.Length)
        {
            Debug.LogError($"Head position {headPos} is out of bounds.");
            return 0;
        }

        return int.Parse(tape.Substring(headPos, 1));
    }

    public void Write(int number)
    {
        string stringNumber = number.ToString();
        tape = tape.Remove(headPos, 1).Insert(headPos, stringNumber);

        if (tapeRenderer != null && headPos >= 0 && headPos < tapeRenderer.cells.Count)
        {
            tapeRenderer.cells[headPos].SetValue(number);
        }

        if (writeVFX != null)
            writeVFX.OnWrite(number);
    }

    public void Move(char direction)
    {
        int newHeadPos = headPos;

        switch (direction)
        {
            case 'L':
                newHeadPos--;
                break;

            case 'R':
                newHeadPos++;
                break;

            case 'N':
                break;

            default:
                Debug.LogWarning($"Unknown move direction: {direction}");
                return;
        }

        if (newHeadPos < 0 || newHeadPos >= tape.Length)
        {
            Debug.LogError($"Cannot move {direction}. New head position {newHeadPos} is out of bounds.");
            return;
        }

        headPos = newHeadPos;

        if (head != null)
            head.MoveTo(headPos);

        Debug.Log($"Moved {direction}. Head is now at {headPos}");
    }
    public void SyncTapeToVisuals()
    {
        if (tapeRenderer == null) return;

        for (int i = 0; i < tape.Length && i < tapeRenderer.cells.Count; i++)
        {
            int value = tape[i] == '1' ? 1 : 0;
            tapeRenderer.cells[i].SetValue(value);
        }
    }
}