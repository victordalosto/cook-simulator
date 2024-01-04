using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameInput : Singleton<GameInput> {

    private event Action EventOnInteract;
    private event Action EventOnInteractAlternate;
    private PlayerInputActions playerActions;


    private new void Awake() {
        base.Awake();
        playerActions = new PlayerInputActions();
        playerActions.Player.Enable();

        playerActions.Player.Interact.performed += ctx => EventOnInteract?.Invoke();
        playerActions.Player.InteractAlternate.performed += ctx => EventOnInteractAlternate?.Invoke();
    }



    public Vector3 getMovementVector() {
        Vector2 inputVector = playerActions.Player.Move.ReadValue<Vector2>();
        return new Vector3(inputVector.x, 0, inputVector.y);
    }



    public void addEventOnInteract(Action action) {
        EventOnInteract += action;
    }


    public void addEventOnInteractAlternate(Action action) {
        EventOnInteractAlternate += action;
    }


    public void removeEventOnInteract(Action action) {
        EventOnInteract -= action;
    }


    public void removeEventOnInteractAlternate(Action action) {
        EventOnInteractAlternate -= action;
    }

}
