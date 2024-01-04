using UnityEngine;


public class CuttingCounter : MonoBehaviour, Interactable {

    private KitchenObjectHolder objectHolder;


    void Start() {
        objectHolder = GetComponentInChildren<KitchenObjectHolder>();
    }



    public void interactAlternate(IPlayerInteractable player) {
        if (objectHolder.hasObject()) {
            KitchenObject kitchenObject = objectHolder.obtainObject();
            if (kitchenObject.isCuttable()) {
                cut(kitchenObject);
            } else {
                objectHolder.placeObject(kitchenObject);
            }
        }
    }



    private void cut(KitchenObject kitchenObject) {
        kitchenObject.cuttingProgress--;
        if (kitchenObject.cuttingProgress > 0) {
            objectHolder.placeObject(kitchenObject);
        } else {
            Debug.Log("Cutting finished");
            kitchenObject.destroy();
            KitchenObjectSO cuttedKitchenObjectSO = kitchenObject.cuttedKitchenObjectSO;
            KitchenObject cuttedKitchenObject = cuttedKitchenObjectSO.createObject(transform);
            objectHolder.placeObject(cuttedKitchenObject);
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
