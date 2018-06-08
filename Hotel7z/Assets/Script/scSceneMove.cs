using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scSceneMove : MonoBehaviour
{
    //누른 버튼의 이름을 미리 받아옴
    public string buttonName;
    public GameObject overEffect;

    public void MoveScene()
    {
        //버튼의 이름을 아래 케이스들과 비교
        switch (buttonName)
        {
            //버튼의 이름이 main이거나 title이면 buttonName의 씬으로 이동
            case "main":
            case "title":
                scPlayer.play = true;
                Cursor.visible = true;
                SceneManager.LoadScene(buttonName);
                break;

            case "saveGame":
                scOptionOnOffer.PCanvas[2].SetActive(true);
                break;

            case "loadGame":
                scOptionOnOffer.PCanvas[1].SetActive(true);
                break;

            //버튼의 이름이 leaveGame이면 게임 종료
            case "leaveGame":
                //SceneManager의 게임 종료를 몰라서 구형식으로 작성함.
                Application.Quit();
                break;
            
            //가져온 SettingCanvas를 활성화
            case "setting":
                scOptionOnOffer.PCanvas[0].SetActive(true);
                break;

            //버튼의 이름이 Back이면 자신의 부모 객체 비활성화
            case "back":
                this.transform.parent.gameObject.SetActive(false);
                if(this.gameObject.name == "BackToGame")
                {
                    scPlayer.play = true;
                    Cursor.visible = false;
                }
                break;

            //아무 버튼도 아닐 시 에러 출력
            default:
                Debug.Log(buttonName + "은 지정되지 않은 버튼 / Unspecified button.");
                break;
        }
    }

    void OnMouseOver()
    {
        if(SceneManager.GetActiveScene().name == "Title")
        {
            overEffect.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            overEffect.SetActive(false);
        }

    }
}
