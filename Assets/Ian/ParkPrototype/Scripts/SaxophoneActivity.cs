using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaxophoneActivity : MonoBehaviour
{
    private SaxophoneInput input;

    private Animator anim;
    private AudioSource audioSource;

    private bool isPlaying;
    private bool isPlayingPerma;

    private float playMeter; // if this thing hits zero while isPlaying but not perma, stop playing

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<SaxophoneInput>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playMeter > 0f)
        {
            playMeter -= Time.deltaTime;
            if (playMeter <= 0f && isPlaying && !isPlayingPerma)
            {
                isPlaying = false;
                if (anim != null) anim.SetTrigger("stopPlayingPlaceholder");
                if (audioSource != null) audioSource.Stop();
            }
        }
    }

    public void PlayActivity()
    {
        if (isPlayingPerma) return;

        playMeter += 1f;
        if (playMeter > 2.5f && !isPlaying)
        {
            if (anim != null) anim.SetTrigger("startPlayingPlaceholder"); //TODO-CHANGE THIS TO THE ACTUAL TRIGGER OF THE ANIMATION
            if (audioSource != null) audioSource.Play();
            isPlaying = true;
        }
        if (playMeter > 5f)
        {
            isPlayingPerma = true;
        }

    }
}
