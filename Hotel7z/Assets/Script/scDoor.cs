using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scDoor : MonoBehaviour
{
    private bool dOn = true;
        
    private Animator doorAni;
    public GameObject Door;

    private AudioSource Audio;
    public AudioClip openSound;
    public AudioClip closeSound;
    
    void Awake()
    {
        Audio = transform.GetComponent<AudioSource>();
    }

    void Start()
    {
       
        doorAni = Door.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
      

    }
   
    public void Open()
    {
        doorAni.SetBool("doorState", dOn);
        if (dOn)
            Audio.PlayOneShot(openSound);
        else
            Audio.PlayOneShot(closeSound);
        dOn = !dOn;
    }

    /*void OpenSound()
    {
        Audio.clip = openSound;

        Audio.Play();
    }*/



}

    

