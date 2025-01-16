using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableObject : MonoBehaviour
{
    public GameObject radishcut;  // Assign in Inspector

    private bool isCut = false;
    

    void OnTriggerEnter(Collider other)
    {
        if (!isCut && other.CompareTag("Knife")) // Ensure the knife has the "Knife" tag
        {
            CutRadish();
        }
    }

    public void CutRadish()
    {
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
}