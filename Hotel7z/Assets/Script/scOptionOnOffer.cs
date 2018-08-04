//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class scOptionOnOffer : MonoBehaviour
//{
//    //Canvas[0] : SettingCanvas, Canvas[1] : LoadCanvase, Canvas[2] : SaveCanvas ,Canvas[3] : PauseCanvas, canvas
//    public GameObject[] Canvas;

//    //PCanvase[0] : Settingcanvas, PCanvase[1] : LoadCanvas, PCanvas[2] : SaveCanvas
//    public static GameObject[] PCanvas = new GameObject[3];

//    void Start()
//    {
//        PCanvas[0] = Canvas[0];
//        PCanvas[1] = Canvas[1];
//        PCanvas[2] = Canvas[2];
//    }

//    void Update ()
//    {
//        OnOffer();
//	}

//    void OnOffer()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape) && scPlayer.play && SceneManager.GetActiveScene().name != "Title")
//        {
//            scPlayer.play = false;
//            Cursor.visible = true;

//            Canvas[3].SetActive(true);
//        }
//        else if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            if (GameObject.Find("SaveCanvas"))
//            {
//                PCanvas[2].SetActive(false);
//            }
//            else if(GameObject.Find("LoadCanvas"))
//            {
//                PCanvas[1].SetActive(false);
//            }
//            else if (GameObject.Find("SettingCanvas"))
//            {
//                PCanvas[0].SetActive(false); ;
//            }
//            else if(SceneManager.GetActiveScene().name != "Title")
//            {
//                scPlayer.play = true;
//                Cursor.visible = false;

//                Canvas[3].SetActive(false);
//            }

//        }
//    }
//}
