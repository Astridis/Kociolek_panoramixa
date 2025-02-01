using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
// using Dialog;

public class BottleShake : MonoBehaviour
{
    public GameObject cork;
    public float shakeThreshold = 2.0f; // Threshold for detecting shakes
    public int requiredShakes = 3; // Number of shakes required to pop the cork
    public float corkPopForce = 10f; // Force applied to the cork when it pops
    public float shakeResetTime = 2.0f; // Time before the shake count resets

    private Vector3 lastFramePosition;
    private Vector3 lastVelocity = Vector3.zero; // Stores velocity of the previous frame
    private int shakeCount = 0;
    private float shakeTimer = 0f;
    public bool corkPopped = false;
    public GameObjectStateSaver objectSaver;
    public bool isGrabbed = false;
    private XRGrabInteractable grabInteractable;

    Dialog dialog;
    // Start is called before the first frame update
    void Start()
    {
        objectSaver = new GameObjectStateSaver(gameObject);
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        grabInteractable.onSelectExited.AddListener(OnReleased);
        lastFramePosition = transform.position;
        dialog = Dialog.Instance;
    }

    void Update()
    {
        if (corkPopped) return;

        // Calculate smoothed velocity
        Vector3 currentVelocity = (transform.position - lastFramePosition) / Time.deltaTime;
        lastFramePosition = transform.position;

        // Check for significant up-down movement (y-axis only)
        float yVelocityDelta = Mathf.Abs(currentVelocity.y - lastVelocity.y);
        lastVelocity = currentVelocity;

        if (yVelocityDelta > shakeThreshold)
        {
            shakeCount++;
            Debug.Log("Shake detected! Count: " + shakeCount);

            if (shakeCount >= requiredShakes)
            {
                PopCork();
            }
        }
        if (yVelocityDelta < shakeThreshold && shakeCount > 0)
        {
            shakeTimer = 0f; // Reset the timer after a valid shake
        }

        // Reset shake count if idle for too long
        shakeTimer += Time.deltaTime;
        if (shakeTimer > shakeResetTime)
        {
            Debug.Log("resetting shakeCount");
            shakeCount = 0;
        }
    }

    void PopCork()
    {
        corkPopped = true;

        // Detach the cork from the bottle
        cork.transform.parent = null;

        // Enable physics on the cork
        Rigidbody corkRigidbody = cork.GetComponent<Rigidbody>();
        corkRigidbody.isKinematic = false; // Allow physics to take over
        corkRigidbody.useGravity = true;  // Ensure gravity is enabled

        // Unfreeze position and rotation constraints if they are locked
        corkRigidbody.constraints = RigidbodyConstraints.None; // Remove any frozen constraints

        // Apply upward force to the cork to simulate it popping
        corkRigidbody.AddForce(Vector3.up * corkPopForce, ForceMode.Impulse);

        Debug.Log("Cork popped!");
    }

    public void resetBottleShake()
    {
        objectSaver.Revert();
        cork.GetComponent<Cork>().resetCork();
        corkPopped = false;
        shakeCount = 0;
        shakeTimer = 0f;
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        isGrabbed = true;
        if (!corkPopped)
        {
            dialog.Show("Shake this bottle 5 times to open it.");
        }
    }

    private void OnReleased(XRBaseInteractor interactor)
    {
        isGrabbed = false;
        Debug.Log("Object is released.");
    }
}
