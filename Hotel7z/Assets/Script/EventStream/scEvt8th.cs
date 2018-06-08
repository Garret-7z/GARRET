using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scEvt8th : MonoBehaviour, iEvent
{
    public GameObject back8;
    public GameObject pencil;
    public GameObject bag;
    public GameObject pannel;
    public GameObject[] Lights = null;
    public scSound sound1;

    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }

    public void Run()
    {
        back8.SendMessage("Open");
        //back8.GetComponent<scSetBool>().isLock = true;
        pencil.SetActive(true);
        bag.SetActive(true);

        for (int i = 0; i < Lights.Length; i++)
        {
            Lights[i].SetActive(false);
        }
        sound1.Run();

        StartCoroutine(theEnd());   //혁수야 힘들지...? 엄마는 다 알아... 
                                    //이 코루틴을 실행시키지 않으면.. 너의 이벤트를 합칠 수 있고..
                                    //이 코루틴을 실행시키면 신현이 이벤트가 끝나면서 메인 타이틀로 돌아갈거야...
                                    //선택은.. 너의 것.. 엄마는 언제나 아들 응원해^^..!
    }

    IEnumerator theEnd()
    {
        yield return new WaitForSeconds(1.0f);

        pannel.SetActive(true);

        yield return new WaitForSeconds(12.5f);

        SceneManager.LoadScene("Title");
    }
}
