using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCut : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cuttable"))
        {
            other.GetComponent<CuttableObject>()?.CutRadish();
        }
    }
}