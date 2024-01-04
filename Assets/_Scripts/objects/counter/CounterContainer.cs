using System;
using System.Collections.Generic;
using UnityEngine;


public class CounterContainer : MonoBehaviour, Interactable {

    [SerializeField]
    private KitchenObjectSO kitchenObjectSO;

    private List<CounterCounter_Visual> counterAnimator;

    private Action EventOnInteract;


    void Start() {
        counterAnimator = new List<CounterCounter_Visual>(GetComponentsInChildren<CounterCounter_Visual>());
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
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, transform);
        kitchenObjectTransform.localPosition = Vector3.zero;
        return kitchenObjectTransform.GetComponent<KitchenObject>();
    }


    public void addEventOnInteract(Action action) {
        EventOnInteract += action;
    }
}
