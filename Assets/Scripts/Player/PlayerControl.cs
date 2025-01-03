using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    //DataManager dataManager;
    PivotEngine engine;
    //Weapon weapon;
    InputAction pivot;

    void Start()
    {
        engine = GetComponent<PivotEngine>();
        //weapon = GetComponent<Weapon>();
        pivot = InputSystem.actions.FindAction("Pivot");
    }

    void Update()
    {
        if (pivot.WasPressedThisFrame()) { engine.TogglePivot(); }
        //if (Input.GetKeyDown(dataManager.toggleKey)) { rotation.TogglePivot(); }
        //if (Input.GetKeyDown(dataManager.abilityKey)) { weapon.Activate(); }
    }
}