using System;
using UnityEngine;


public class Player : Singleton<Player>, Interactable{

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
        gameInput.OnInteractEvent += handleInteractions;
    }


    private void Update() {
        fisica.handleMovement(this);
    }


    public bool isMoving() {
        return attributes.IsMoving;
    }


    public void handleInteractions() {
        SelectedCounter?.interact(this);
    }


    public void setSelectedCounter(Interactable counter) {
        SelectedCounter = counter;
        ActionOnSelectedCounterChanged?.Invoke(SelectedCounter);
    }


    public void interact(Interactable other) {
        throw new NotImplementedException();
    }
}