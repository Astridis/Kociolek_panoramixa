using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CuttableObject : MonoBehaviour
{
    public GameObject radishcut;  // Assign in Inspector
    private bool isCut = false;
    public GameObjectStateSaver objectSaver;
    public bool isGrabbed = false;
    private XRGrabInteractable grabInteractable;
    // Start is called before the first frame update
    void Start()
    {
        objectSaver = new GameObjectStateSaver(gameObject);
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        grabInteractable.onSelectExited.AddListener(OnReleased);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isCut && other.CompareTag("Knife"))
        {
            other.GetComponent<KnifeCut>()?.IsCuttingMotion(); // Optional: log or check directly
            CutRadish();
        }
    }

    public void CutRadish()
    {
        if (isCut) return; // Prevent multiple cuts
        isCut = true;

        Vector3 originalPosition = transform.position;
        Quaternion originalRotation = transform.rotation;

        radishcut.transform.position = originalPosition;
        radishcut.transform.rotation = originalRotation;

        // Hide the whole radish
        gameObject.SetActive(false);

        // Enable the two halves
        radishcut.SetActive(true);

        // Add Rigidbody so they can move
        radishcut.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void resetRadish()
    {
        objectSaver.Revert();
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        isGrabbed = true;
        Debug.Log("Object is grabbed.");
    }

    private void OnReleased(XRBaseInteractor interactor)
    {
        isGrabbed = false;
        Debug.Log("Object is released.");
    }
}
