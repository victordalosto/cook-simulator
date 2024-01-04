using UnityEngine;


public class Counter : MonoBehaviour, Interactable {

    private KitchenObjectHolder objectHolder;


    void Start() {
        objectHolder = GetComponentInChildren<KitchenObjectHolder>();
    }


    // #DELETE this after tests
    private void Update() {
        if (Input.GetKeyDown(KeyCode.F1)) {
            KitchenObject kitchenObject = objectHolder.obtainObject();
            if (kitchenObject != null) {
                Destroy(kitchenObject.gameObject);
            }
        }
    }



    public void interact(IPlayerInteractable player) {
        IObjectHolder<KitchenObject> playerObjectHolder = player.getObjectHolder();
        if (playerObjectHolder.hasObject()) {
            placeItemInCounter(playerObjectHolder);
        } else {
            obtainItemInCounter(playerObjectHolder);
        }
    }



    private void placeItemInCounter(IObjectHolder<KitchenObject> playerObjectHolder) {
        if (objectHolder.hasObject()) {
            // Counter is full
        } else {
            // Counter has space
            KitchenObject kitchenObject = playerObjectHolder.obtainObject();
            objectHolder.placeObject(kitchenObject);
        }
    }



    private void obtainItemInCounter(IObjectHolder<KitchenObject> playerObjectHolder) {
        if (objectHolder.hasObject()) {
            // Counter has item to give
            KitchenObject kitchenObject = objectHolder.obtainObject();
            playerObjectHolder.placeObject(kitchenObject);
        } else {
            // No item to give
        }
    }
}
