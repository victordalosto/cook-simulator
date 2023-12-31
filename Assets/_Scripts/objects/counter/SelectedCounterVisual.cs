using UnityEngine;


public class SelectedCounterScript : MonoBehaviour {

    private Interactable interactable;

    private GameObject visualGameObject;


    private void Start() {
        interactable = GetComponentInParent<ClearCounter>();
        visualGameObject = gameObject.GetComponentInChildren<Transform>().gameObject;
        Player.Instance.ActionOnSelectedCounterChanged += ChangeSelectedCounter;
        Hide();
    }



    private void ChangeSelectedCounter(Interactable interactable) {
        if (interactable == this.interactable) {
            Show();
        } else {
            Hide();
        }
    }



    private void Show() {
        visualGameObject.SetActive(true);
    }



    private void Hide() {
        visualGameObject.SetActive(false);
    }

}
