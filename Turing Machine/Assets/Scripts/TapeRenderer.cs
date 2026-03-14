using UnityEngine;
using System.Collections.Generic;

public class TapeRenderer : MonoBehaviour
{
    public TapeCell cellPrefab;
    public int tapeLength = 21;
    public float spacing = 1.2f;

    public List<TapeCell> cells = new List<TapeCell>();

    void Start()
    {
        GenerateTape();
    }

    void GenerateTape()
    {
        for (int i = 0; i < tapeLength; i++)
        {
            Vector3 pos = transform.position + Vector3.right * (i * spacing);

            TapeCell cell = Instantiate(cellPrefab, pos, Quaternion.identity, transform);
            cell.SetValue(0);

            cells.Add(cell);
        }
    }
}