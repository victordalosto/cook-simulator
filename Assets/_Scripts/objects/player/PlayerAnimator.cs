using UnityEngine;


public class PlayerAnimator : MonoBehaviour {

    private Player player;

    private Animator animator;


    private void Awake() {
        player = GetComponentInParent<Player>();
        animator = GetComponent<Animator>();
        animator.SetBool(ContainerManager.IS_WALKING, false);
    }


    private void Update() {
        animator.SetBool(ContainerManager.IS_WALKING, player.IsMoving());
    }

}
