using System;
using UnityEngine;


public class Player : Singleton<Player>, IPlayerInteractable {

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
        gameInput.addEventOnInteract(interact);
        gameInput.addEventOnInteractAlternate(interactAlternate);
    }



    public void setSelectedCounter(Interactable counter) {
        SelectedCounter = counter;
        ActionOnSelectedCounterChanged?.Invoke(SelectedCounter);
    }



    public void interact() {
        SelectedCounter?.interact(this);
    }



    public void interactAlternate() {
        SelectedCounter?.interactAlternate(this);
    }


    public IObjectHolder<KitchenObject> getObjectHolder() {
        return objectHolder;
    }
}