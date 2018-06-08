using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class scMemo : MonoBehaviour {
    //private string file;
   // private string textValue;
    public bool memoState = false;
    private MeshRenderer memoNote;
    public Text memoname;
    // Use this for initialization
    void Start()
    {
        memoNote = gameObject.GetComponentInChildren<MeshRenderer>();
        //file = @"C:\Users\admin\Documents\GitHub\Exsistence";
        //TextAsset textfile = Resources.Load(memoname) as TextAsset;
        //textValue = " " + textfile;
        //Debug.Log(textValue);
    }
	
	// Update is called once per frame
	void Update () {

        if (memoState != false)
        {
            memoNote.enabled = false;
        }
        else
            memoNote.enabled = true;
        // memoCheck();
    }
  void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            LoadMemo();
            memoState = true;




        }
    }

    private static void LoadMemo()
    {
        //scMemoManage.instance.StringLoad(memoname);
    }
}
