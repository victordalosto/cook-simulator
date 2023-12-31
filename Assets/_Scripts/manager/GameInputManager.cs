using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameInput : Singleton<GameInput> {

    public event Action OnInteractEvent;
    private PlayerInputActions playerActions;


    private new void Awake() {
        base.Awake();
        playerActions = new PlayerInputActions();
        playerActions.Player.Enable();
        playerActions.Player.Interact.performed += userInteraction;
    }



    public Vector3 getMovementVector() {
        Vector2 inputVector = playerActions.Player.Move.ReadValue<Vector2>();
        return new Vector3(inputVector.x, 0, inputVector.y);
    }



    private void userInteraction(InputAction.CallbackContext context) {
        OnInteractEvent?.Invoke();
    }

}
