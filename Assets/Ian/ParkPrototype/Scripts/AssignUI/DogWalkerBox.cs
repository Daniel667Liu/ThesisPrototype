using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DogWalkerBox : Box
{
    public LayerMask keyLayer;
    private Transform pointer;

    private string[] validBotLeftKeys = new string[] {"`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=",
     "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "\\",
     "a", "s", "d", "f", "g", "h", "j", "k", "l", ";", "'",
     "z", "x", "c", "v", "b", "n", "m", ",", ".", "/", "down", "up", "left", "right"};

    // Start is called before the first frame update
    void Start()
    {
        pointer = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override Vector3 CheckInput()
    {
        RaycastHit hit;
        Vector3 origin = new Vector3(pointer.position.x, pointer.position.y, Camera.main.transform.position.z);
        if (Physics.Raycast(origin, Camera.main.transform.forward, out hit, Mathf.Infinity, keyLayer))
        {
            Debug.Log(hit.collider.name);
            if (validBotLeftKeys.Contains(hit.collider.name))
            {
                return hit.collider.transform.position + (transform.position - pointer.position);
            }
        }

        return new Vector3(-1001, 0, 0);
    }
}
