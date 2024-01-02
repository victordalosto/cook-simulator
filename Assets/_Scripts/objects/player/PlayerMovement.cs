using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    private Player player;
    private GameInput gameInput;
    private PlayerAttributes attributes;


    void Start() {
        this.player = GetComponentInParent<Player>();
        this.gameInput = player.gameInput;
        this.attributes = player.attributes;
    }


    void Update() {
        handleMovement();
    }



    public void handleMovement() {
        Vector3 movementVector = gameInput.getMovementVector();
        attributes.IsMoving = movementVector.magnitude > 0;

        if (!attributes.IsMoving) {
            return;
        }

        changePlayerRotation(player.transform, movementVector);
        changePlayerPosition(player.transform, movementVector);
        returnInteractableNearPlayer(player, movementVector);
    }



    public void returnInteractableNearPlayer(Player player, Vector3 movementVector) {
        attributes.LastInteractDirection = movementVector;
        bool isInteracting = Physics.Raycast(player.transform.position, attributes.LastInteractDirection,
                                             out RaycastHit hit, attributes.InteractionDistance,
                                             ContainerManager.Instance.getCounterLayerMask());
        if (isInteracting
            && hit.transform.TryGetComponent(out Interactable counter))
        {
            player.setSelectedCounter(counter);
        } else {
            player.setSelectedCounter(null);
        }
    }



    private void changePlayerRotation(Transform transform, Vector3 movementVector) {
        transform.forward = Vector3.Slerp(transform.forward, movementVector, Time.deltaTime * attributes.RotateSpeeds);
    }



    private void changePlayerPosition(Transform transform, Vector3 movementVector) {
        float moveDistance = attributes.MovementSpeed * Time.deltaTime;
        bool canMove = isCollidinAround(transform, movementVector, moveDistance);
        if (!canMove) {
            canMove = tryChangePlayerDirectionToMove(transform, ref movementVector, moveDistance);
        }
        if (canMove) {
            transform.position += moveDistance * movementVector.normalized;
        }
    }



    private bool isCollidinAround(Transform target, Vector3 moveVector, float moveDistance) {
        return !Physics.CapsuleCast(target.position,
                                    target.position + Vector3.up * attributes.PlayerHeight,
                                    attributes.PlayerRadius,
                                    moveVector,
                                    moveDistance);
    }



    private bool tryChangePlayerDirectionToMove(Transform transform,
                                                ref Vector3 movementVector,
                                                float moveDistance) {
        bool canMove;
        Vector3 moveDirX = new(movementVector.x, 0, 0);
        canMove = isCollidinAround(transform, moveDirX, moveDistance);
        if (canMove) {
            movementVector = moveDirX;
        } else {
            Vector3 moveDirZ = new(0, 0, movementVector.z);
            canMove = isCollidinAround(transform, moveDirZ, moveDistance);
            if (canMove) {
                movementVector = moveDirZ;
            }
        }
        return canMove;
    }

}