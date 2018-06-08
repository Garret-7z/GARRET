using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scEnding03 : MonoBehaviour
{
    public GameObject[] light;
    //[0] : Player, [1] : Point, [2] : Camera
    public Transform[] transformOb;
    public AudioClip audioClip;
    public Sprite image;
    public Image fadein;

    public float audioTimer;
    public float speed = 0;

    private Animator Anim;
    private AudioSource Audio;
    private SpriteRenderer render;

    private bool die = false;
    private int count = 0;


    void Start()
    {
        Audio = transform.GetComponent<AudioSource>();
        Anim = transform.GetComponent<Animator>();
        render = transform.GetComponent<SpriteRenderer>();
        fadein = GameObject.Find("FadeIn").GetComponent<Image>();

        Anim.enabled = false;

        
    }
    void Update()
    {
        
        if (scGameManager.instance.eventIndex == -3)
        {
            if(count == 0)
            {
                count++;
                transformOb[0].LookAt(transformOb[1]);
            }

            if (!die) Anim.enabled = true;
            else
            {
                Anim.enabled = false;
                StartCoroutine(FadeIn());
            }

            Ending();
        }
    } 

    void Ending()
    {
        scPlayer.play = false;

        for (int i = 0; i < light.Length; i++)
            light[i].SetActive(false);
    }

    void Move()
    {
        transform.LookAt(transformOb[0]);
        GameObject step = Resources.Load("Prefabs/Ending03 Effect") as GameObject;

        Audio.clip = audioClip;

        if(transform.position.x - transformOb[0].position.x > 0)
            transform.position = new Vector3(transform.position.x - speed, 0, 0);
        render.flipY = false;

        if (transform.position.x - transformOb[0].position.x < 0)
        {
            transform.position = new Vector3(transform.position.x + speed, 0, 0);
            render.flipY = true;
        }

        step.GetComponent<SpriteRenderer>().flipX = render.flipX;
        step.GetComponent<SpriteRenderer>().flipY = render.flipY;
        step.transform.position = transform.position;
        Instantiate(step);

        Audio.time = audioTimer;
        if(Audio.time <= audioTimer) Audio.Play();
        Audio.Stop();
    }

    IEnumerator FadeIn()
    {
        for (float i = 0; i <= 10; i += 0.1f)
        {
            Color color = new Color(0, 0, 0, i);
            fadein.color = color;

            yield return 0;
        }
        SceneManager.LoadScene("title");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player" && scGameManager.instance.eventIndex == -3)
        {
            transform.rotation = new Quaternion(-90,0,90,0);
            render.sprite = image;
            render.enabled = true;

            die = true;
        }
    }
}
