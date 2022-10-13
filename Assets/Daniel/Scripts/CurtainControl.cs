using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class CurtainControl : MonoBehaviour
{
    private PlayableDirector pd;
    private AudioSource audioSource;
    public AudioClip upSound;
    public AudioClip downSound;
    bool a = true;
    bool b = true;
    
    // Start is called before the first frame update
    void Start()
    {
        pd = GetComponent<PlayableDirector>();
        audioSource = GetComponentInChildren<AudioSource>();


        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        pd.Play();
        DragCurtain();
        SoundControl();
    }

    void DragCurtain() 
    {
        pd.time += Input.mouseScrollDelta.y;
        if (pd.time < 0) 
        {
            pd.time = 0;
        }
        if (pd.time > 5) 
        {
            pd.time = 5;
        }
    }

    public void PlayUpSound() 
    {
        audioSource.clip = upSound;
        audioSource.Play();
    }

    public void PlayDownSound() 
    {
        audioSource.clip = downSound;
        audioSource.Play();
    }

    public void SoundControl() 
    {
        if (pd.time == 0) 
        {
            if(a)
            {
                audioSource.clip = upSound;
                audioSource.Play();
                a = false;
            }
        }
        if (pd.time == 5) 
        {
            if (b) 
            {
                audioSource.clip = downSound;
                audioSource.Play();
                b = false;
            }
        }
        if (pd.time > 0.2) 
        {
            a = true;
        }
        if (pd.time < 4.8) 
        {
            b = true;
        }

    }

    public void StopCurtain()
    {
        pd.Pause();
    }
}
