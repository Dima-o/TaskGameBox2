using UnityEngine;
using UnityEngine.UI;

public class ObjectWithHint : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectText;
    [SerializeField] private Text textHints;
    [SerializeField] private string textInteractingWithObject;

    private void Start()
    {
        gameObjectText.SetActive(false);
        textHints.text = textInteractingWithObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            textHints.text = textInteractingWithObject;
            gameObjectText.SetActive(true);   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            gameObjectText.SetActive(false);
        }
    }
}
