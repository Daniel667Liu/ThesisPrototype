using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManActivity : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    public Material sit;
    public Material prepare;
    public Material feed;
    MeshRenderer meshR;
    int geziIndex = 0;
    public GameObject[] gezis;
    List<GameObject> groundGeZi;
    // Start is called before the first frame update
    void Start()
    {
        groundGeZi = new List<GameObject>();
        meshR = GetComponent<MeshRenderer>();
        if (TryGetComponent<Animator>(out animator))
        {
        }
        else
        {
            Debug.Log("no animator attached to old man");
        }
        if (TryGetComponent<AudioSource>(out audioSource))
        {
        }
        else
        {
            Debug.Log("no audio source attached to oldman");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PrepareFood()
    {
        //start prepare food
        animator.SetTrigger("prepare");
    }

    

    public void PrepareStop()
    {
        animator.SetTrigger("prepareStop");

    }
    public void Feed()
    {
        //seccussfully feed
        //should set a bool in animator, since this func  will be called muti-times
        animator.SetTrigger("feed");
        GeZiLai();
    }

    void GeZiLai() 
    {
        if (geziIndex < gezis.Length)
        {
            gezis[geziIndex].GetComponent<Animator>().SetTrigger("come");
            groundGeZi.Add(gezis[geziIndex]);
            geziIndex += 1;
        }
        else 
        {
            geziIndex = 0;
        }
        
    }

    public void ResetTriggers()
    {
        animator.ResetTrigger("feed");
    }

    //call when the dog is near and bark
    public void Bark() 
    {
        //animator.SetTrigger("Bark");
        for (int i = groundGeZi.Count-1; i >=0 ; i--) 
        {
            groundGeZi[i].GetComponent<Animator>().SetTrigger("go");
            groundGeZi.RemoveAt(i);
        }
    }
}
