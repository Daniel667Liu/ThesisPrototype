using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandActivity : MonoBehaviour
{
    private Animator anim;
    private AudioSource audioSource;

    private bool isPlaying;
    private float playMeter;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playMeter > 0f)
        {
            playMeter -= Time.deltaTime;

            if (playMeter > 3f)
            {
                anim.speed = ((playMeter > 4f) ? 4 : playMeter) - 3f;
                audioSource.volume = ((playMeter > 4f) ? 4 : playMeter) - 3f;
                isPlaying = true;
            }
            else
            {
                isPlaying = false;
            }

        }
    }

    public void PlayActivity()
    {
        playMeter += 1f;

        if (playMeter > 4.5f) playMeter = 4.5f;

    }
}
