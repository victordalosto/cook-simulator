using System;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Player : Singleton<Player>, PlayerInteractable {

    [field:SerializeField]
    public GameInput gameInput { get; private set; }

    public PlayerAttributes attributes { get; private set; }

    private Interactable SelectedCounter;

    public event Action<Interactable> ActionOnSelectedCounterChanged;

    private KitchenObjectHolder objectHolder;


    private new void Awake() {
        base.Awake();
        attributes = GetComponentInChildren<PlayerAttributes>();
        objectHolder = GetComponentInChildren<KitchenObjectHolder>();
        gameInput.OnInteractEvent += interact;
    }



    public void setSelectedCounter(Interactable counter) {
        SelectedCounter = counter;
        ActionOnSelectedCounterChanged?.Invoke(SelectedCounter);
    }



    public void interact() {
        SelectedCounter?.interact(this);
    }


    public IObjectHolder<KitchenObject> getObjectHolder() {
        return objectHolder;
    }
}