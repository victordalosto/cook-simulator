using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SelectedCounterVisual : MonoBehaviour {

    private Interactable interactable;

    private List<GameObject> visualGameObject;


    private void Awake() {
        interactable = GetComponentInParent<Interactable>();
        visualGameObject = transform.Cast<Transform>().Select(child => child.gameObject).ToList();
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
        foreach (GameObject go in visualGameObject) {
            go.SetActive(true);
        }
    }



    private void hide() {
        foreach (GameObject go in visualGameObject) {
            go.SetActive(false);
        }
    }

}
