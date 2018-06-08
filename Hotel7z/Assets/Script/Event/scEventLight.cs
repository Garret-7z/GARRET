using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scEventLight : MonoBehaviour, iEvent
{
    public scEventRunner Runner;
    public GameObject obj;

    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }
    // Use this for initialization
    void Start()
    {
        Runner.SetEvent(this);
    }

    public void Run()
    {
        obj.SetActive(false);
        Debug.Log("avs");
    }

}
