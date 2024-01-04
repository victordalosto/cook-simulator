using UnityEngine;


public class CounterCounter_Visual : MonoBehaviour {

    private Animator animator;



    private void Start() {
        animator = GetComponent<Animator>();
        animator.SetBool(ContainerManager.Animacoes.COUNTER_OPEN_CLOSE, false);

        CounterContainer counterContainer = GetComponentInParent<CounterContainer>();
        counterContainer.addEventOnInteract(playAnimation);
    }



    public void playAnimation() {
        animator.SetBool(ContainerManager.Animacoes.COUNTER_OPEN_CLOSE, true);
    }


}
