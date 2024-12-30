using UnityEngine;

public class Wall : MonoBehaviour
{
    public enum WallDirection
    {
        Up,
        Right,
        Down,
        Left
    }

    public WallDirection wallDirection;
}
