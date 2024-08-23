using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI InteractableText;

    private void Awake()
    {
        InteractableText.gameObject.SetActive(false);
    }

    public GameObject GetInteractText()
    {
        return InteractableText.gameObject;
    }
}
