using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scMemoManage : MonoBehaviour {
    public static scMemoManage instance;
    private string file;
    private string textValue;
    //public bool memoState = false;
   // private MeshRenderer memoNote;
    //public string memoname;
    public List<string> memonames = new List<string>();
     List<string> list = new List<string>();
    // Use this for initialization
    void Awake()
    {
       scMemoManage.instance = this;   
    }
    void Start () {
        //memoNote = gameObject.GetComponentInChildren<MeshRenderer>();
        //file = @"C:\Users\admin\Documents\GitHub\Exsistence";
        //TextAsset textfile = Resources.Load(memoname) as TextAsset;
        //textValue = " " + textfile;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StringLoad(string memoname)
    {
        TextAsset textfile = Resources.Load(memoname) as TextAsset;
        textValue = " " + textfile;
        list.Add(textValue);
        Debug.Log(list.Contains(" System check()"));
        Debug.Log(textValue);
    }
}
