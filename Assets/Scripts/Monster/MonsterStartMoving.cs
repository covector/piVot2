using UnityEngine;

public class MonsterStartMoving : MonoBehaviour
{
    public void StartMoving()
    {
        transform.parent.GetComponent<Monster>().StartMoving();
    }
}
