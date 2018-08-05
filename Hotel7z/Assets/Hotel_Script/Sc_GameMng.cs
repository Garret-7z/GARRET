using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GameMng : MonoBehaviour {

    private static Sc_GameMng _instance = null;
    public static Sc_GameMng instance
    {
        get
        {
            if (_instance == null) // 
                Debug.LogError("싱글턴 == null");
            return _instance;
        }
    }
    // Timechecker 코루틴에 필요한 변수들
    float timeTemp = 0f; // 현재 시간
    public bool timeStop = false; // 시간을 멈출 때 씀 트루는 멈추게함

    [HideInInspector]
    public string[] TagNames = new string []{"CHANGE/Mirror/MirrorReflection", "CHANGE/TimsAssets_Door/Door_Wood/Door_Main1",};


    //
    [HideInInspector]
    public GameObject[] gameObjects_Door;
    public Material bloodyDoorPR; //Tag : CHANGE/TimsAssets_Door/Door_Wood/Door_Main1
    public Material [] bloodyDoorPRs;

    [HideInInspector]
    public GameObject[] gameObjects_Mirror;
    public Material mirrorMaterial;// Tag : Change_Mirror/MirrorReflection
    public Material [] mirrorMaterials;
    string TagName = "";
    private void Awake()
    {
        _instance = this;


        ////히어라이키에 있는 특정 태그를 찾은 후에 배열에 싹다 담는 작업
        //for (int i = 0; i < ChangeOBJs.GetLength(0); i++)
        //{
        //    TagName = TagNames[i];
        //    for (int j = 0; j < ChangeOBJs.GetLength(1); j++)
        //    {
        //        ChangeOBJs[i, j] = GameObject.FindGameObjectWithTag(TagName);
        //        if (ChangeOBJs[i, j] == null)
        //        {
        //            Debug.LogError("@@@@@@ChangeOBJs[i, j]초기화 안됨!");
        //        }
        //    }
        //}

        //// 싹다 담긴 배열을 초기화

        //TagName = TagNames[0]; // Change_Mirror/MirrorReflection
        //for (int i = 0; i < ChangeOBJs.GetLength(1); i++)
        //{
        //    bloodyDoorPRs[i] = ChangeOBJs[0, i].GetComponent<Renderer>().material;
        //}

        //TagName = TagNames[1]; // CHANGE/TimsAssets_Door/Door_Wood/Door_Main1
        //for (int i = 0; i < ChangeOBJs.GetLength(1); i++)
        //{
        //    mirrorMaterials[i] = ChangeOBJs[0, i].GetComponent<Renderer>().material;
        //}








    }
    private void OnEnable()
    {
        gameObjects_Mirror = GameObject.FindGameObjectsWithTag("CHANGE/Mirror/MirrorReflection");
        gameObjects_Door = GameObject.FindGameObjectsWithTag("CHANGE/TimsAssets_Door/Door_Wood/Door_Main1");

    }
    void Start () {
        timeTemp = Time.time;

        //bloodyDoorPR = ChangeOBJs[0].transform.Find("Door_Main1").GetComponent<Renderer>().material;
        
        
        StartCoroutine("TimeChecker");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator TimeChecker()//RaycastHit hit
    {
        while (true)
        {
            if (timeStop == false)
            {
                timeTemp += Time.deltaTime;
                
            }
            else if(timeStop == true)
            {
                timeTemp = 0;
            }
            //Debug.Log("timeTemp : " + timeTemp);
            yield return null;
        }

    }
}
