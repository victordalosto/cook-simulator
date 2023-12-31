using System;
using UnityEngine;


public class Player : Singleton<Player> {

    [SerializeField]
    private GameInput gameInput;

    private PlayerPhysics fisica;

    private PlayerAttributes attributes;

    private ICounter SelectedCounter;

    public event Action<ICounter> ActionOnSelectedCounterChanged;


    private new void Awake() {
        base.Awake();
        attributes = GetComponentInChildren<PlayerAttributes>();
        fisica = new PlayerPhysics(gameInput, attributes);
        gameInput.OnInteractEvent += handleInteractions;
    }


    private void Update() {
        fisica.HandleMovement(this);
    }


    public bool isMoving() {
        return attributes.IsMoving;
    }


    public void handleInteractions() {
        SelectedCounter?.interact();
    }


    public void setSelectedCounter(ICounter counter) {
        SelectedCounter = counter;
        ActionOnSelectedCounterChanged?.Invoke(SelectedCounter);
    }

}