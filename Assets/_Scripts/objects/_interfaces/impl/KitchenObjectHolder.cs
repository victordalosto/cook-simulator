using UnityEngine;


public class KitchenObjectHolder : MonoBehaviour, IObjectHolder<KitchenObject> {

    private KitchenObject currentObject;

    void Start() {
        currentObject = null;
    }

    void OnDestroy() {
        currentObject = null;
    }


    public bool hasObject() {
        return currentObject != null;
    }


    public void placeObject(KitchenObject obj) {
        if (!hasObject() && obj != null) {
            currentObject = obj;
            obj.transform.position = transform.position;
            obj.transform.SetParent(transform);
        }
    }


    public KitchenObject obtainObject() {
        KitchenObject obj = currentObject;
        currentObject = null;
        return obj;
    }

}