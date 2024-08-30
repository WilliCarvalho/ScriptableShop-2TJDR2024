using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private GameObject playerBody;
    private CharacterController characterController;

    private void Awake() => characterController = GetComponent<CharacterController>();

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(GameManager.Instance.InputManager.Movement.x,
                                            0,
                                          GameManager.Instance.InputManager.Movement.y);
        characterController.SimpleMove(moveDirection * moveSpeed);
        RotatePlayerAccordingToInput(moveDirection);
    }

    private void RotatePlayerAccordingToInput(Vector3 moveDirection)
    {
        Vector3 pointToLookAt;
        pointToLookAt.x = moveDirection.x;
        pointToLookAt.y = 0;
        pointToLookAt.z = moveDirection.z;
        
        Quaternion currentRotation = playerBody.transform.rotation;

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotarion = Quaternion.LookRotation(pointToLookAt);

            playerBody.transform.rotation = Quaternion.Slerp(currentRotation, targetRotarion, moveSpeed * Time.deltaTime);
        }
    }
}
