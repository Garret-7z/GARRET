using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 박세찬
public class scSound : MonoBehaviour, iEvent
{

    public AudioSource audioPlayer; // 음악 플레이어 
    public AudioClip []SoundClip; // 실제 음악 파일 

    public int SoundClip_i=0;


    [Range(0f, 1f)]
    public float soundVolume = 1f; // 음악 불륨 

    public bool loopSet = false; //몇 번 루프할건지(혹은 무한), 얼마나 지속되는지
    public bool rangeSeting; // 이거 체크하면 게임안에서 크기 변경 가능함 
    public bool Allplay = false; // 모두 한번에 재생할것인지? 


    [Range(0f, 15f)]
    public float soundMinDistance = 8f;
    [Range(15f, 30f)]
    public float soundMaxDistance = 25f;

    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }
    // Use this for initialization
    void Awake()
    {
        
        audioPlayer =gameObject.GetComponent<AudioSource>();
        //SoundClip = gameObject.GetComponent<AudioClip>(); // 겟컴포넌트가 모든걸 가져오는건 아님 
        // 오브젝트형은 겟컴포넌트로 못함 그래서 null되었던거임 
        soundSet();
        audioPlayer.loop = loopSet;
        for (int i = 0; i < SoundClip.Length; i++)
        {
            audioPlayer.clip = SoundClip[i];

        }
        

    }
     

    void Start()
    {
        //audioPlayer.PlayOneShot(SoundClip);
        //StartCoroutine(play());
    }
    // Update is called once per frame
    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (rangeSeting == true)
        {
            soundSet();// 계속 값 바꾸고 싶어서 update에 놓음 
        }

        if (!audioPlayer.isPlaying && loopSet)
            co_play();
    }

    public void soundSet() // 소리 들리는 범위 설정 함수 
    {
        audioPlayer.minDistance = soundMinDistance;
        audioPlayer.maxDistance = soundMaxDistance;
        audioPlayer.loop = loopSet;
        audioPlayer.volume = soundVolume;
    }

    public void Run()
    {
        if (Allplay)
        {
            loopSet = true;
            Allplay = false; // false로 초기화 
            StartCoroutine(co_play());
        }
        else
        {
            StartCoroutine(co_play(SoundClip_i));
        }
        
    }

   

    IEnumerator co_play() // 한번에 배열에 있는 음악 모두 재생
    {
        Debug.Log("isPlaying ::"+audioPlayer.isPlaying);

        for (int i = 0; i < SoundClip.Length; i++)
        {
            audioPlayer.PlayOneShot(SoundClip[i]);
            
            Debug.Log(":: NowPlaying ::" + i);
        }
        yield return null;

    }
    IEnumerator co_play(int SoundClip_i) // 몇 번째에 있는 음악만 재생   
    {
        this.SoundClip_i = SoundClip_i;
        audioPlayer.Play();
        yield return null;
    }
}
