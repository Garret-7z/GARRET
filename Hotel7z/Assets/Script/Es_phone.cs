using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Es_phone : MonoBehaviour {

    public AudioSource audioPlayer; // 음악 플레이어 
    public AudioClip[] SoundClip; // 실제 음악 파일 
                                  // Use this for initialization
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void startPlay()
    {
        StartCoroutine(play());
    }
    IEnumerator play() // 한번에 배열에 있는 음악 모두 재생
    {
        Debug.Log("isPlaying ::" + audioPlayer.isPlaying);

        for (int i = 0; i < SoundClip.Length; i++)
        {
            audioPlayer.PlayOneShot(SoundClip[i]);

            Debug.Log(":: NowPlaying ::" + i);
        }
        yield return null;

    }
}
