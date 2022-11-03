using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkActivity : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    public GameObject gezi;
    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent<Animator>(out animator))
        {
        }
        else 
        {
            Debug.Log("no animator attached to firework");
        }
        if (TryGetComponent<AudioSource>(out audioSource))
        {
        }
        else 
        {
            Debug.Log("no audio source attached to the firework");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //playe the effect of halfway
    public void HalfSuccess() 
    {
        animator.SetBool("Hold", false);
    }


    //play the effect of successful interaction
    public void Success() 
    {
        //animator.SetBool("HalfSuccess", false);
        animator.SetTrigger("boom");
        animator.SetBool("Hold", false);
        Vector3 pos = transform.position;

        Invoke("ShootBird", 0.2f);
    }

    //play the effect when of start to interact with
    public void StartInteract() 
    {
       animator.SetBool("Hold", true);
    }

    private void ShootBird()
    {
        GameObject clone = Instantiate(gezi);
        //clone.transform.position = new Vector3(-0.5024103f, -0.4296535f, -0.765976f);
        clone.transform.position = new Vector3(-0.55f, -0.48f, -0.79f);
        clone.transform.eulerAngles = new Vector3(6.59f, -5.088f, -15.5f);
    }
}
