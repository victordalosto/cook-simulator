using UnityEngine;


[CreateAssetMenu(fileName = "New Kitchen Object", menuName = "KitchenObjectSO")]
public class KitchenObjectSO : ScriptableObject {

    [field:SerializeField, Header("Kitchen Object Name")]
    public string objectName { get; private set; }

    [field:SerializeField, Header("Prefab")]
    public Transform prefab { get; private set; }

    [field:SerializeField, Header("Sprite UI")]
    public Sprite sprite { get; private set; }


}