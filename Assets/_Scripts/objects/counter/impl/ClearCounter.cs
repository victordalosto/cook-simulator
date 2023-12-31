using UnityEngine;


public class ClearCounter : MonoBehaviour, Interactable {

    public bool CanInteract() => true;

    public void Interact() {
        Debug.Log("OK!!! ClearCounter.Interact()");
    }

}