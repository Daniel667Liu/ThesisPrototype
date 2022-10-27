using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumsActivity : MonoBehaviour
{
    public AudioClip loopClip;
    public AudioClip[] individualSounds = new AudioClip[4];


    private DrumsInput input;

    private Animator anim;
    private AudioSource audioSource;

    private bool isPlayingPerma;

    private float playMeter; // if it's larger than 6, start playing on its own

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<DrumsInput>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playMeter > 0f)
        {
            playMeter -= Time.deltaTime;
        }
    }

    public void PlayActivity(int num)
    {
        if (isPlayingPerma) return;

        playMeter += 1f;

        if (playMeter > 6f)
        {
            isPlayingPerma = true;
            if (anim != null) anim.SetTrigger("PermaPlayTriggerPlaceholder"); //TODO CHANGE THIS
            if (audioSource != null)
            {
                audioSource.clip = loopClip;
                audioSource.Play();
            }

            Debug.Log("perma playing drums");
            return;
        }


        switch (num)
        {
            case 0:
                if (anim != null) anim.SetTrigger("Hit0TriggerPlaceholder"); //TODO CHANGE THIS
                if (audioSource != null)
                {
                    audioSource.PlayOneShot(individualSounds[0]);
                }
                break;
            case 1:
                if (anim != null) anim.SetTrigger("Hit1TriggerPlaceholder"); //TODO CHANGE THIS
                if (audioSource != null)
                {
                    audioSource.PlayOneShot(individualSounds[1]);
                }
                break;
            case 2:
                if (anim != null) anim.SetTrigger("Hit2TriggerPlaceholder"); //TODO CHANGE THIS
                if (audioSource != null)
                {
                    audioSource.PlayOneShot(individualSounds[2]);
                }
                break;
            case 3:
                if (anim != null) anim.SetTrigger("Hit3TriggerPlaceholder"); //TODO CHANGE THIS
                if (audioSource != null)
                {
                    audioSource.PlayOneShot(individualSounds[3]);
                }
                break;
        }
    }
}
