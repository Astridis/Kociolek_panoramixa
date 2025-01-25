using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCut : MonoBehaviour
{
    public float minCutVelocity = 1.0f;  // Minimum velocity to register a cut
    public float angleThreshold = 45.0f; // Maximum allowable angle deviation for a cut

    private Vector3 previousPosition;
    private Vector3 knifeVelocity;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        // Calculate velocity of the knife
        knifeVelocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cuttable"))
        {
            // Check velocity and angle conditions
            if (IsCuttingMotion())
            {
                other.GetComponent<CuttableObject>()?.CutRadish();
            }
        }
    }

    public bool IsCuttingMotion()
    {
        // Check if the knife velocity is high enough
        if (knifeVelocity.magnitude < minCutVelocity)
            return false;

        // Check if the cutting angle is within the threshold
        Vector3 knifeDirection = transform.forward; // Forward direction of the knife
        Vector3 velocityDirection = knifeVelocity.normalized;

        float angle = Vector3.Angle(knifeDirection, velocityDirection);
        return angle <= angleThreshold;
    }
}
