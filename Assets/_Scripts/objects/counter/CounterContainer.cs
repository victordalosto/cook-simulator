using System;
using System.Collections.Generic;
using UnityEngine;


public class CounterContainer : MonoBehaviour, Interactable {

    [SerializeField]
    private KitchenObjectSO kitchenObjectSO;

    private List<CounterCounter_Visual> counterAnimator;

    public Action EventOnInteract;


    void Start() {
        counterAnimator = new List<CounterCounter_Visual>(GetComponentsInChildren<CounterCounter_Visual>());
    }



    public void interactAlternate(IPlayerInteractable player) {
    }



    public void interact(IPlayerInteractable player) {
        IObjectHolder<KitchenObject> playerObjectHolder = player.getObjectHolder();
        if (!playerObjectHolder.hasObject()) {
            KitchenObject kitchenObject = createObject();
            playerObjectHolder.placeObject(kitchenObject);
            EventOnInteract?.Invoke();
        }
    }


    private KitchenObject createObject() {
        return kitchenObjectSO.createObject(transform);
    }
}
