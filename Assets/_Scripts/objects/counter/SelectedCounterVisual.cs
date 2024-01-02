using UnityEngine;


public class SelectedCounterVisual : MonoBehaviour {

    private Interactable interactable;

    private GameObject visualGameObject;


    private void Awake() {
        interactable = GetComponentInParent<Counter>();
        visualGameObject = transform.GetChild(0).gameObject;
        hide();
    }

    private void Start() {
        Player.Instance.ActionOnSelectedCounterChanged += changeSelectedCounter;
    }

    private void OnDestroy() {
        if (Player.Instance != null)
            Player.Instance.ActionOnSelectedCounterChanged -= changeSelectedCounter;
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
