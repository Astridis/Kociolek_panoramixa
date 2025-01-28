using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cork : MonoBehaviour
{
    public GameObjectStateSaver objectSaver;

    // Start is called before the first frame update
    void Start()
    {
        objectSaver = new GameObjectStateSaver(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetCork()
    {
        objectSaver.Revert();
    }
}
