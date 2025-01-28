using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PotionRed : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {

    }

    public void resetPotionRed()
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
