using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scMesh : MonoBehaviour {
    public MeshCollider[] mesh;
    public GameObject[] objs;
	// Use this for initialization
	void Start () {

        
        for (int i = 0; i <= objs.Length; i++)
        {
            mesh[i] = objs[i].AddComponent<MeshCollider>() as MeshCollider;
        }
        


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
