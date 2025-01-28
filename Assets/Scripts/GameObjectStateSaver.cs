using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class GameObjectStateSaver : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }
// }

public class GameObjectStateSaver
{
    private GameObject obj;
    private Vector3 position;
    private Quaternion rotation;
    private Vector3 localScale;
    private GameObject parent;
    private bool active;
    private Vector3 angVel;

    public GameObjectStateSaver(GameObject obj)
    {
        this.obj = obj;

        position = obj.transform.position;
        rotation = obj.transform.rotation;
        localScale = obj.transform.localScale;
        // parent = obj.transform.parent.gameObject;
        active = obj.activeSelf;
        angVel = obj.GetComponent<Rigidbody>().angularVelocity;
    }

    public void Revert()
    {
        obj.GetComponent<Rigidbody>().Sleep();
        obj.GetComponent<Rigidbody>().angularVelocity = angVel;
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.transform.localScale = localScale;
        // obj.transform.SetParent(parent.transform);
        obj.SetActive(active);
        obj.GetComponent<Rigidbody>().WakeUp();
    }
}