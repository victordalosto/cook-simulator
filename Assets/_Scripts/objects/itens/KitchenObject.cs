using UnityEngine;

public class KitchenObject : MonoBehaviour {

    [field:SerializeField]
    public KitchenObjectSO kitchenObjectSO { get; private set; }

    private Interactable counter;


    public void Start() {
        counter = null;
    }


    public void setCounter(Interactable counter) {
        this.counter = counter;
    }


    public Interactable getCounter() {
        return counter;
    }


}
