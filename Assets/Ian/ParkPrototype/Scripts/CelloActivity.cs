using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelloActivity : MonoBehaviour
{
    public CelloInput input;

    private Animator anim;
    private AudioSource audioSource;

    private bool isPlayingPerma;
    private bool isPlaying;
    private float playMeter;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<CelloInput>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playMeter > 0f)
        {
            playMeter -= Time.deltaTime;
            if (playMeter <= 0f && isPlaying && isPlayingPerma)
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
        if (playMeter > 3f && !isPlaying)
        {
            isPlaying = true;
            if (anim != null) anim.SetTrigger("startPlayingPlaceholder"); //TODO-CHANGE THIS TO THE ACTUAL TRIGGER OF THE ANIMATION
            if (audioSource != null) audioSource.Play();
        }
        if (playMeter > 6f)
        {
            isPlayingPerma = true;
        }
    }
}
