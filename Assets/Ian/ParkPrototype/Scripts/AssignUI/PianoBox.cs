using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PianoBox : Box
{
    public BandInput bandInput;

    public LayerMask keyLayer;
    private Transform pointer;

    private string[] validBotLeftKeys = new string[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", 
      "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "s", "d", "f", "g", "h", "j", "k", "l", 
     "x", "c", "v", "b", "n", "m", ","};

    private string[] keyboardLayout = new string[] {"`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=",
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
                KeyCode[] keys = getKeys(hit.collider.name);
                if (bandInput != null) bandInput.AssignKeys(keys[0], keys[1], keys[2], keys[3]);
                return hit.collider.transform.position + (transform.position - pointer.position);
            }
        }

        return new Vector3(-1001, 0, 0);
    }

    public KeyCode[] getKeys(string pointerKey)
    {
        KeyCode[] keys = new KeyCode[4];

        int ind = -1;
        for (int i = 0; i < keyboardLayout.Length; i++)
        {
            if (pointerKey.Equals(keyboardLayout[i]))
            {
                ind = i;
                break;
            }
        }
        /*
                keys[0] = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyboardLayout[ind - 1]);
                keys[1] = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyboardLayout[ind]);
                keys[2] = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyboardLayout[ind + 1]);
                keys[3] = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyboardLayout[ind + 2]);*/

        keys[0] = (KeyCode)(int)(keyboardLayout[ind - 1][0]);
        keys[1] = (KeyCode)(int)(keyboardLayout[ind][0]);
        keys[2] = (KeyCode)(int)(keyboardLayout[ind + 1][0]);
        keys[3] = (KeyCode)(int)(keyboardLayout[ind + 2][0]);

        return keys;
    }
}
