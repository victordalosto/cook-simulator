using UnityEngine;

public class KitchenObject : MonoBehaviour {

    [field:SerializeField]
    public KitchenObjectSO kitchenObjectSO { get; private set; }

    private ICounter counter;


    public void Start() {
        counter = null;
    }


    public void setCounter(ICounter counter) {
        this.counter = counter;
        counter?.placeObject(this);
    }


    public ICounter getCounter() {
        return counter;
    }


}
