using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RadishCut : MonoBehaviour
{
    public CuttableObject radish;  // Assign in Inspector
    public bool isGrabbed = false;
    private XRGrabInteractable grabInteractable;
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        grabInteractable.onSelectExited.AddListener(OnReleased);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetRadish()
    {
        radish.objectSaver.Revert();
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
