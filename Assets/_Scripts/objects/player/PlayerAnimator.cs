using UnityEngine;


public class PlayerAnimator : MonoBehaviour {

    private PlayerAttributes playerAttributes;

    private Animator animator;


    private void Start() {
        Player player = GetComponentInParent<Player>();
        playerAttributes = player.attributes;
        animator = GetComponent<Animator>();
        animator.SetBool(ContainerManager.Animacoes.PLAYER_IS_WALKING, false);
    }


    private void Update() {
        animator.SetBool(ContainerManager.Animacoes.PLAYER_IS_WALKING, playerAttributes.IsMoving);
    }

}
