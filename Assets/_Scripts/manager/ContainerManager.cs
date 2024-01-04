using UnityEngine;


public class ContainerManager : Singleton<ContainerManager> {

    [SerializeField]
    private LayerMask COUNTER_LAYER_MASK;



    public LayerMask getCounterLayerMask() {
        return COUNTER_LAYER_MASK;
    }



    public static class Animacoes {
        public static readonly string PLAYER_IS_WALKING = "IsWalking";
        public static readonly string COUNTER_OPEN_CLOSE = "OpenClose";
    }

}