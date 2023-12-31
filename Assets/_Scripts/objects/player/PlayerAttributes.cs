using UnityEngine;


public class PlayerAttributes : MonoBehaviour {

    [field:SerializeField]
    public float MovementSpeed { get; private set; } = 7f;

    [field:SerializeField]
    public float PlayerRadius { get; private set; } = 0.6f;

    [field:SerializeField]
    public float PlayerHeight { get; private set; } = 2.58f;

    [field:SerializeField]
    public float InteractionDistance { get; private set; } = 2f;

    [field:SerializeField]
    public float RotateSpeeds { get; private set; } = 25f;

    public bool IsMoving = false;
    public Vector3 LastInteractDirection = Vector3.zero;


}
