using System;
using UnityEngine;


public class Player : Singleton<Player> {

    [SerializeField]
    private GameInput gameInput;

    private PlayerPhysics fisica;

    private PlayerAttributes attributes;

    private Interactable SelectedCounter;

    public event Action<Interactable> ActionOnSelectedCounterChanged;


    private new void Awake() {
        base.Awake();
        attributes = GetComponentInChildren<PlayerAttributes>();
        fisica = new PlayerPhysics(gameInput, attributes);
        gameInput.OnInteractEvent += HandleInteractions;
    }


    private void Update() {
        fisica.HandleMovement(this, transform);
    }


    public bool IsMoving() {
        return attributes.IsMoving;
    }


    public void HandleInteractions() {
        SelectedCounter?.Interact();
    }


    public void SetSelectedCounter(Interactable interactable) {
        SelectedCounter = interactable;
        ActionOnSelectedCounterChanged?.Invoke(SelectedCounter);
    }

}