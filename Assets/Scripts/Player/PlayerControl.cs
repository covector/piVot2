using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //DataManager dataManager;
    PivotEngine engine;
    //Weapon weapon;

    void Start()
    {
        engine = GetComponent<PivotEngine>();
        //weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) { engine.TogglePivot(); }
        //if (Input.GetKeyDown(dataManager.toggleKey)) { rotation.TogglePivot(); }
        //if (Input.GetKeyDown(dataManager.abilityKey)) { weapon.Activate(); }
    }
}