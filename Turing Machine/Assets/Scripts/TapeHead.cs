using UnityEngine;

public class TapeHead : MonoBehaviour
{
    public TapeRenderer tape;

    public void MoveTo(int index)
    {
        if (tape == null)
        {
            Debug.LogError("TapeHead: tape reference is missing.");
            return;
        }

        if (tape.cells == null || tape.cells.Count == 0)
        {
            Debug.LogError("TapeHead: tape has no cells.");
            return;
        }

        if (index < 0 || index >= tape.cells.Count)
        {
            Debug.LogError($"TapeHead: index {index} is out of range.");
            return;
        }

        Vector3 targetPos = tape.cells[index].transform.position + Vector3.up * 0.6f;
        transform.position = targetPos;

        Debug.Log($"TapeHead moved to index {index}, target {targetPos}");
    }
}