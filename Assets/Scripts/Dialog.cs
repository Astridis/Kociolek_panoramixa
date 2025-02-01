using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    // private Rect windowRect = new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 200, 300);
    private bool show = false;
    private string message;


    private static Dialog _instance;
    public static Dialog Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("get instance FAIL");
            }
            else
            {
                Debug.Log("get instance SUCCESS");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void OnGUI()
    {
        if (show)
        {
            GUI.Box(new Rect((Screen.width / 2) - 200, 0, 400, 100), message);
            // windowRect = GUI.Window(0, windowRect, DialogWindow, "Title");
        }
    }

    // void DialogWindow(int windowID)
    // {
    //     // GUI.Label(new Rect(5, 20, windowRect.width, 20), message);
    //     // if (GUI.Button(new Rect(5, 50, windowRect.width - 10, 20), "OK"))
    //     // {
    //     //     show = false;
    //     // }
    // }

    public void Show(string msg)
    {
        Debug.Log(msg);
        message = msg;
        show = true;
        StartCoroutine(disappearBoxAfter(3.0f));
    }

    IEnumerator disappearBoxAfter(float waitTime)
    {
        // suspend execution for waitTime seconds
        yield return new WaitForSeconds(waitTime);
        show = false;
    }

    void Update()
    {
        // OnGUI();
    }
}
