using UnityEngine;


public class SelectedCounterVisual : MonoBehaviour {

    private ICounter interactable;

    private GameObject visualGameObject;


    private void Start() {
        interactable = GetComponentInParent<ClearCounter>();
        visualGameObject = gameObject.GetComponentInChildren<Transform>().gameObject;
        Player.Instance.ActionOnSelectedCounterChanged += changeSelectedCounter;
        hide();
    }



    private void changeSelectedCounter(ICounter counter) {
        if (counter == this.interactable) {
            show();
        } else {
            hide();
        }
    }



    private void show() {
        visualGameObject.SetActive(true);
    }



    private void hide() {
        visualGameObject.SetActive(false);
    }

}
