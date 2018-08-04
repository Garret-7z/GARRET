using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Sound : MonoBehaviour {

    private static Sc_Sound _instance = null;
    public static Sc_Sound _Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("싱글턴 == null");
            return _instance;
        }
    }
    public AudioSource audioPlayer; // 음악 플레이어 
    public AudioClip[] SoundClip; // 실제 음악 파일 
    public GameObject Soundinstance;
    public int SoundClip_i = 0;

    [Range(0f, 1f)]
    public float soundVolume = 1f; // 음악 불륨 

    public bool loopSet = false; //몇 번 루프할건지(혹은 무한), 얼마나 지속되는지
    public bool rangeSeting; // 이거 체크하면 게임안에서 크기 변경 가능함 
    public bool Allplay =   false; // 모두 한번에 재생할것인지? 


    // Use this for initialization
    private void Awake()
    {
        _instance = this;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void soundSet() // 소리 설정 함수 
    {
        audioPlayer.loop = loopSet;
        audioPlayer.volume = soundVolume;
    }
    public void Run(int num , Transform transform)
    {
        GameObject temp = Instantiate(Soundinstance, transform);
        audioPlayer.PlayOneShot(SoundClip[num]);
        Destroy(temp, 3f);
    }
}
