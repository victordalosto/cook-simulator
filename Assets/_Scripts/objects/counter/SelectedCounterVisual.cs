using UnityEngine;


public class SelectedCounterVisual : MonoBehaviour {

    private Interactable interactable;

    private GameObject visualGameObject;


    private void Start() {
        interactable = GetComponentInParent<Counter>();
        visualGameObject = gameObject.GetComponentInChildren<Transform>().gameObject;
        Player.Instance.ActionOnSelectedCounterChanged += changeSelectedCounter;
        hide();
    }



    private void changeSelectedCounter(Interactable counter) {
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
