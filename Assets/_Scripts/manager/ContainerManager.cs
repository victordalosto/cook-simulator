using UnityEngine;


public class ContainerManager : Singleton<ContainerManager> {

    [SerializeField]
    private LayerMask COUNTER_LAYER_MASK;

    public const string IS_WALKING = "IsWalking";


    public LayerMask GetCounterLayerMask() {
        return COUNTER_LAYER_MASK;
    }

}