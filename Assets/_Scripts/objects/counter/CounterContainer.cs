using UnityEngine;


public class CounterContainer : MonoBehaviour, Interactable {

    [SerializeField]
    private KitchenObjectSO kitchenObjectSO;


    public void interact(PlayerInteractable player) {
        IObjectHolder<KitchenObject> playerObjectHolder = player.getObjectHolder();
        if (!playerObjectHolder.hasObject()) {
            KitchenObject kitchenObject = createObject();
            playerObjectHolder.placeObject(kitchenObject);
        }
    }


    private KitchenObject createObject() {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, transform);
        kitchenObjectTransform.localPosition = Vector3.zero;
        return kitchenObjectTransform.GetComponent<KitchenObject>();
    }
}
