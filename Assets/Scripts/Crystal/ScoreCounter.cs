using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class ScoreCounter : MonoBehaviour
{
    private int count = 0;
    public TextMeshProUGUI counter;

    private void Start()
    {
        Display();
    }

    public void Increment()
    {
        count++;
        Display();
    }

    public void Reset()
    {
        count = 0;
        Display();
    }
    private void Display()
    {
        counter.text = count > 0 ? count.ToString() : "";
    }

    public int GetCount() { return count; }
}