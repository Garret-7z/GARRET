using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_lab : MonoBehaviour {
    GameObject TestOBJ72;
    GameObject [] Tests;
    // Use this for initialization
    private void Awake()
    {
        //Tests = GameObject.FindGameObjectsWithTag("TEST/123"); //SetActive(false);
    }
    void Start () {
        
    }
    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update () {
        Test();
    }
    void Test()
    {

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    Tests = GameObject.FindGameObjectsWithTag("TEST/123"); //SetActive(false);

        //    foreach (GameObject obj in Tests)
        //    {
        //        obj.SetActive(false);
        //    }
        //}
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P 누름!!");
            Debug.Log(Sc_GameMng.instance.gameObjects_Mirror[0].name);
            
            if (Sc_GameMng.instance.gameObjects_Door == null)
            {
                Debug.Log("NULL값이야!");
            }
            else
            {
                foreach (GameObject obj in Sc_GameMng.instance.gameObjects_Mirror)
                {
                    Debug.Log("FOREACH");
                    obj.SetActive(false);
                }
            }
            foreach (GameObject obj in Sc_GameMng.instance.gameObjects_Door)
            {
                Debug.Log("FOREACH");
                obj.SetActive(false);
            }
        }

    }
}
