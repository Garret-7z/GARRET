using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scEventMain2 : MonoBehaviour ,iEvent{
    public scSound sound1;
    public scSound sound2;

    // Use this for initialization
    void Update () {

    }
    public void Run()
    {
        sound1.Run();
        sound2.Run();
    }
    
    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }
}
