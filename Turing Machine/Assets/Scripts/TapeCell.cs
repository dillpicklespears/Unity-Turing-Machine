using UnityEngine;
using TMPro;

public class TapeCell : MonoBehaviour
{
    public int value;

    [SerializeField] private TextMeshPro text;
    [SerializeField] private Renderer cellRenderer;

    public void SetValue(int v)
    {
        value = v;
        text.text = v.ToString();

        if (v == 0)
            cellRenderer.material.color = Color.red;
        else
            cellRenderer.material.color = Color.blue;
    }

    public void Highlight(bool on)
    {
        if (on)
            cellRenderer.material.color = Color.yellow;
        else
            SetValue(value);
    }
}