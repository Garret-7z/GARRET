using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scSetting : MonoBehaviour
{
    static float ambientValue = 0.6f;
    static float audioVolume = 1f;

    public void Awake()
    { 
        Setting();

        DontDestroyOnLoad(this.gameObject);

        this.transform.parent.gameObject.SetActive(false);
    }

    private void OnGUI()
    {
        //x 스크린.X / 2 - 400, y 스크린.y / 2 + 250 위치에 가로, 세로 100, 50 인 슬라이더를 생성(최소 0, 최대 1);
        // 슬라이더 생성
        GUI.Box(new Rect(Screen.width / 2 -3, Screen.height / 2 -20, 105, 35), "화면 밝기");
        ambientValue = GUI.HorizontalSlider(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), ambientValue, 0f, 1.0f);

        GUI.Box(new Rect(Screen.width / 2 -3, Screen.height / 2 -120, 105, 35), "오디오 볼륨");
        audioVolume = GUI.HorizontalSlider(new Rect(Screen.width / 2, Screen.height / 2 -100, 100, 50), audioVolume, 0f, 1.0f);

        Setting();
    }

    private void Setting()
    {
        //화면 밝기 설정
        RenderSettings.ambientLight = new Color(ambientValue, ambientValue, ambientValue, 1);

        //오디오 설정
        if (GameObject.FindObjectsOfType(typeof(AudioSource)) != null)
        {
            foreach (AudioSource audioComponent in GameObject.FindObjectsOfType(typeof(AudioSource)))
            {
                audioComponent.volume = audioVolume;
            }
        }
    }
}
