using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public Vector2 iniMousePos;
    public List<Vector2> dirs;
    public GameObject key;
    private Animator doorAnimator;
    private AudioSource audioSource;
    public AudioClip unlocking;
    public AudioClip unlocked;
    public AudioClip doorClose;
    bool doorOpened;
    public GameObject[] people;

    private bool keyIn;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();

        this.enabled = false;
    }

    void Update()
    {
        OpenDoor();

        //for test
        /*
        if (Input.GetKey(KeyCode.Space)) 
        {
            PeopleWalkIn();
        }
        */
    }

    void OpenDoor()
    {
        if (!doorOpened) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                iniMousePos = Input.mousePosition;
                doorAnimator.SetTrigger("InsertKey");
                keyIn = true;
                PlayUnlockingSound();
            }
            if (Input.GetMouseButton(0))
            {
                //if the line length is longer than 100, get the dir line
                if (Vector2.Distance(Input.mousePosition, iniMousePos) > 20)
                {
                    Vector2 pos = Input.mousePosition;
                    Vector2 dir = pos - iniMousePos;


                    if (dirs.Count == 0) //there is no dir in this list
                    {
                        dirs.Add(dir);
                    }
                    else
                    {
                        //check the angle between this dir and last dir
                        if (Vector2.SignedAngle(dir, dirs[dirs.Count - 1]) > 0 && Vector2.SignedAngle(dir, dirs[dirs.Count - 1]) < 80)
                        {
                            dirs.Add(dir);
                        }
                        //else clear the list and add this dir into list
                        else
                        {
                            dirs.Clear();
                            dirs.Add(dir);
                        }
                    }
                    iniMousePos = pos;

                }
                if (dirs.Count >= 6)
                {
                    //do what need to open the door
                    Debug.Log("open the door");
                    PlayUnlockedSound();
                    dirs.Clear();
                    doorAnimator.SetTrigger("RotateKey");
                    doorOpened = true;
                }
            }
            //end the check process and clear the list
            if (Input.GetMouseButtonUp(0))
            {
                dirs.Clear();
                iniMousePos = Vector2.zero;
                if (key != null && keyIn)
                {
                    doorAnimator.SetTrigger("Reverse");
                    keyIn = false;
                }
            }
        }
        
    }

    public void CloseDoor()
    {
        doorAnimator.SetTrigger("Close");
        PlayDoorCLoseSound();
    }
    public void DestroyKey()
    {
        Destroy(key);
    }

    void PlayUnlockingSound()
    {
        audioSource.clip = unlocking;
        audioSource.Play();
    }

    public void PlayUnlockedSound() 
    {
        audioSource.clip = unlocked;
        audioSource.Play();
    }

    public void PlayDoorCLoseSound() 
    {
        audioSource.clip = doorClose;
        audioSource.Play();
    }

    public void PeopleWalkIn() 
    {
        for (int i = 0; i < people.Length; i++) 
        {
            people[i].GetComponent<Animator>().enabled = true;
        }
    }
}
