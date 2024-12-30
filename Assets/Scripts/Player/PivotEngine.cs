using UnityEngine;
using static Wall;
using static Utils;

public class PivotEngine : MonoBehaviour
{
    Vector2 tailPos;
    Vector2 headPos;
    public Transform obj;
    public Transform tail;
    public Transform head;
    public float angularSpeed;
    int direction = -1;  // -1->clockwise 1->anticlockwise
    bool pivotAtHead = false;

    private void Start()
    {
        tailPos = tail.localPosition;
        headPos = head.localPosition;
        obj.localPosition = pivotAtHead ? -headPos :-tailPos;
    }

    void Update()
    {
        transform.eulerAngles += Time.deltaTime * direction * angularSpeed * Vector3.forward;
    }

    public void SetPivot(bool atHead)
    {
        Vector2 offset = (Vector2)obj.localPosition + (atHead ? headPos : tailPos);
        Vector2 rotatedOffset = Rotate2D(offset, transform.eulerAngles.z);
        transform.localPosition += Mult(rotatedOffset, transform.localScale);
        obj.localPosition = pivotAtHead ? -headPos : -tailPos;
    }

    public void TogglePivot()
    {
        pivotAtHead = !pivotAtHead;
        SetPivot(pivotAtHead);

        if (!pivotAtHead) { GetComponent<PlayerParticles>().PlayFeetGroundParticles(tail.position); }
    }

    public void WallHit(bool signalFromHead, WallDirection hitWallDir)
    {
        if (pivotAtHead == signalFromHead) return;
        switch (hitWallDir)
        {
            case WallDirection.Up:
                direction = (head.position.x > tail.position.x) == signalFromHead ? -1 : 1;
                break;
            case WallDirection.Right:
                direction = (head.position.y > tail.position.y) == signalFromHead ? 1 : -1;
                break;
            case WallDirection.Down:
                direction = (head.position.x > tail.position.x) == signalFromHead ? 1 : -1;
                break;
            case WallDirection.Left:
                direction = (head.position.y > tail.position.y) == signalFromHead ? -1 : 1;
                break;
        }
    }
}