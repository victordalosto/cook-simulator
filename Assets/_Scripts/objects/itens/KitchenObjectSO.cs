using UnityEngine;


[CreateAssetMenu(fileName = "New Kitchen Object", menuName = "KitchenObjectSO")]
public class KitchenObjectSO : ScriptableObject {

    [field:SerializeField, Header("Kitchen Object Name")]
    public string objectName { get; private set; }

    [field:SerializeField, Header("Prefab")]
    public Transform prefab { get; private set; }

    [field:SerializeField, Header("Sprite UI")]
    public Sprite sprite { get; private set; }



    public KitchenObject createObject(Transform transform) {
        Transform kitchenObjectTransform = Instantiate(prefab, transform);
        kitchenObjectTransform.localPosition = Vector3.zero;
        return kitchenObjectTransform.GetComponent<KitchenObject>();
    }


}