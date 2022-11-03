using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandActivity : MonoBehaviour
{
    public GameObject crowd;

    private Animator anim;
    private AudioSource audioSource;

    private bool isPlaying;
    private float playMeter;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        anim.speed = 0;
        audioSource.volume = 0;
        setCrowdSpeed(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (playMeter > 0f)
        {
            playMeter -= Time.deltaTime * 1.5f;

            if (playMeter > 2.5f)
            {
                float val = ((playMeter > 3.5f) ? 3.5f : playMeter) - 2.5f;
                anim.speed = val;
                if (!audioSource.isPlaying) audioSource.Play();
                audioSource.volume = val;
                setCrowdSpeed(val);
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

        if (playMeter > 4.0f) playMeter = 4.0f;

    }

    private void setCrowdSpeed(float speed)
    {
        if (crowd == null) return;

        for (int i=0; i<crowd.transform.childCount; i++)
        {
            if (i == 4) continue;

            Animator ani = crowd.transform.GetChild(i).GetChild(0).GetComponent<Animator>();
            ani.speed = speed;
        }
    }
}
