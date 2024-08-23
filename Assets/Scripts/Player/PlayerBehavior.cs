using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private GameObject playerBody;
    [SerializeField] private LayerMask InteractableLayer;
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

    private void OnTriggerEnter(Collider other)
    {
        print("triggering " + other.gameObject.layer);
        print(InteractableLayer.value);
        if(other.gameObject.layer == 3)
        {
            other.GetComponent<Interactable>().GetInteractText().SetActive(true);
            GameManager.Instance.InputManager.EnableInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            other.GetComponent<Interactable>().GetInteractText().SetActive(false);
            GameManager.Instance.InputManager.DisableInteraction();
            GameManager.Instance.CloseShopUI();
        }
    }
}
