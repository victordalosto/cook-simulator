using UnityEngine;


public class ClearCounter : MonoBehaviour, ICounter {

    [SerializeField]
    private KitchenObjectSO kitchenObjectSO;

    [SerializeField]
    private Transform topPosition;

    private KitchenObject currentKitchenObject;

    [SerializeField, Header("Testing Purpose.. #DELETE")]
    private ClearCounter secondCounter;



    private void Start() {
        currentKitchenObject = null;
    }



    // #DELETE this after tests
    private void Update() {
        if (Input.GetKeyDown(KeyCode.T) && currentKitchenObject != null) {
            currentKitchenObject.setCounter(secondCounter);
            placeObject(null);
        }
        Debug.Log("Current Kitchen Object: " + currentKitchenObject);
    }



    public bool isInteractable() {
        return true;
    }



    public void placeObject(KitchenObject kitchenObject) {
        this.currentKitchenObject = kitchenObject;
        if (kitchenObject != null) {
            kitchenObject.transform.position = topPosition.position;
        }
    }



    public void interact() {
        if (currentKitchenObject == null) {
            currentKitchenObject = createObject();
            currentKitchenObject.setCounter(this);
        } else {
            Debug.Log("The counter: " + currentKitchenObject.getCounter()
                    + " is already occupied with: " + currentKitchenObject.kitchenObjectSO.objectName);
        }
    }


    private KitchenObject createObject() {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, topPosition);
        kitchenObjectTransform.localPosition = Vector3.zero;
        return kitchenObjectTransform.GetComponent<KitchenObject>();
    }

}