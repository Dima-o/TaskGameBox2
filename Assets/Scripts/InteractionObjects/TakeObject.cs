using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [SerializeField] private GameObject windowButtonF;
    [SerializeField] private GameObject windowBookReminder;
    [SerializeField] private GameObject buttonInBook;
    [SerializeField] private float timerActivityWindow;

    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    private float timer;
    private bool activeTimer;
    private bool activeKeyF;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        windowButtonF.SetActive(false);
        windowBookReminder.SetActive(false);
        activeKeyF = false;
        timer = timerActivityWindow;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && activeKeyF)
        {
            activeTimer = true;
            windowButtonF.SetActive(false);
            meshRenderer.enabled = false;
            buttonInBook.SetActive(true);
            activeKeyF = false;
            boxCollider.enabled = false;
        }

        if (activeTimer)
        {
            LaunchTimer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            windowButtonF.SetActive(true);
            activeKeyF = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            windowButtonF.SetActive(false);
            activeKeyF = false;
        }
    }

    private void LaunchTimer()
    {
        timer -= Time.deltaTime;

        if (timer > 0)
        {
            windowBookReminder.SetActive(true);
        }
        else
        {
            windowBookReminder.SetActive(false);
            activeTimer = false;
            Destroy(gameObject);
        }
    } 
}
