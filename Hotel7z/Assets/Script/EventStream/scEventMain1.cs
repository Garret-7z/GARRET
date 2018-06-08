using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scEventMain1 : MonoBehaviour {
    public GameObject afternoonLight; // 오후 조명 
    public GameObject nightLight;     // 저녁 조명 
    
    // 초기 조명은 afternoonLight = ture , nightLight = false

    public SpriteRenderer blackFade;
    public scSound sound1;
    public scSound sound2;
    public scSound sound3;
    public scSound BGM;
    public scGameManager indx;
    Animator Ani;
    // Use this for initialization
    void Start () {
        //scCamera camera72 = GetComponent<scCamera>();

        //Animator playerg = player.GetComponent<RuntimeAnimatorController>();
        //RuntimeAnimatorController runAni = gameObject.GetComponent<RuntimeAnimatorController>();
        Ani = gameObject.GetComponent<Animator>();
        

        
            
    }
	
	// Update is called once per frame
	void Update()
    {
        
    }

    void TrunOffLight()
    {
        Debug.Log("밤느낌이 나도록 조명 조정");
        //nightLight.SetActive(true);
        RenderSettings.ambientSkyColor = new Color(0.1f, 0.1f, 0.1f);
    }

    void DoorOpen()
    {
        Debug.Log("문이 열려야함!!");
    }

    void PlaySound()
    {
        //Debug.Log("소리");
        sound1.Run(); // 모든소리가 나옴 
        sound2.Run();
        sound3.Run();

    }

    void ChangeWindow()
    {
        Debug.Log("창밖 이미지가 밤으로 교체되어야 함 ");
    }

    void TrunOffAni()
    {
        Ani.enabled = false;
        Debug.Log("애니메이터꺼짐 ");
    }

    void TrunOffSound()
    {
        sound1.audioPlayer.Stop();
        sound2.audioPlayer.Stop();
        sound3.audioPlayer.Stop();
        Debug.Log("음악꺼짐");
        indx.eventIndex++;
        BGM.Run();
    }


    IEnumerator FadeIn() // 자고 일어났을때 눈을 뜨게하는 효과를 넣기 위해 일단 보류 
    {
        for (float i = 1f; i >= 0;i-=0.1f)
        {
            Color color = new Vector4(1, 1, 1, i);
            blackFade.color = color;

            yield return new WaitForSeconds(1f);
        }
    }
    


    


}
