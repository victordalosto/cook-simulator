using UnityEngine;

public class KitchenObject : MonoBehaviour {

    [field:SerializeField]
    public KitchenObjectSO kitchenObjectSO { get; private set; }

    [field:SerializeField]
    public KitchenObjectSO cuttedKitchenObjectSO { get; private set; }

    [field:SerializeField]
    public int cuttingProgress { get; set; }


    public void destroy() {
        Destroy(gameObject);
    }


    public bool isCuttable() {
        return cuttedKitchenObjectSO != null;
    }


}
