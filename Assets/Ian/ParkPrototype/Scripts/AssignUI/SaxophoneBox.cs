using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaxophoneBox : Box
{
    public LayerMask keyLayer;

    private string[] validMiddleKeys = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", 
    "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "s", "d", "f", "g", "h", "j", "k", "l", ";",
    "x", "c", "v", "b", "n", "m", ",", ".", "down"};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override Vector3 CheckInput()
    {
        // 0, -80, 80
        RaycastHit hit;
        Vector3 origin = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        if (Physics.Raycast(origin, Camera.main.transform.forward, out hit, Mathf.Infinity, keyLayer)) 
        {
            Debug.Log(hit.collider.name);
            if (validMiddleKeys.Contains(hit.collider.name))
            {
                return hit.collider.transform.position;
            }
        }

        return new Vector3(-1001, 0, 0);
    }
}
