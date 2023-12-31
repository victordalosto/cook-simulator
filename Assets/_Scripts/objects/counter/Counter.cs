using UnityEngine;


public class Counter : MonoBehaviour, Interactable {

    [SerializeField]
    private KitchenObjectSO kitchenObjectSO;

    private KitchenObjectHolder objectHolder;


    private void Start() {
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



    public void interact(Interactable other) {
        if (!objectHolder.hasObject()) {
            KitchenObject kitchenObject = createObject();
            objectHolder.placeObject(kitchenObject);
        } else {
            Debug.Log("The counte is already occupied with.");
        }
    }



    private KitchenObject createObject() {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, objectHolder.transform);
        kitchenObjectTransform.localPosition = Vector3.zero;
        return kitchenObjectTransform.GetComponent<KitchenObject>();
    }

}
