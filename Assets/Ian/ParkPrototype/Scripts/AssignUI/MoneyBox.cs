using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoneyBox : Box
{
    public MoneyInput moneyInput;

    public LayerMask keyLayer;
    private Transform pointer;

    private string[] validBotLeftKeys = new string[] {"`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-",
     "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "]",
     "a", "s", "d", "f", "g", "h", "j", "k", "l", ";",
     "z", "x", "c", "v", "b", "n", "m", ",", ".", "down", "left"};

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
        //Vector3 origin = new Vector3(pointer.position.x, pointer.position.y, Camera.main.transform.position.z);
        Vector3 origin = new Vector3(pointer.position.x, pointer.position.y, pointer.position.z) - pointer.forward;
        if (Physics.Raycast(origin, Camera.main.transform.forward, out hit, Mathf.Infinity, keyLayer))
        {
            Debug.Log(hit.collider.name);
            if (validBotLeftKeys.Contains(hit.collider.name))
            {
                KeyCode[] keys = getKeys(hit.collider.name);
                if (moneyInput != null) moneyInput.AssignKeys(keys[0], keys[1]);
                return hit.collider.transform.position + (transform.position - pointer.position);
            }
        }

        return new Vector3(-1001, 0, 0);
    }

    public KeyCode[] getKeys(string pointerKey)
    {
        KeyCode[] keys = new KeyCode[2];

        if (pointerKey.Equals("down"))
        {
            keys[0] = KeyCode.DownArrow;
            keys[1] = KeyCode.RightArrow;
            return keys;
        }
        if (pointerKey.Equals("left"))
        {
            keys[0] = KeyCode.LeftArrow;
            keys[1] = KeyCode.DownArrow;
            return keys;
        }

        int ind = -1;
        for (int i = 0; i < keyboardLayout.Length; i++)
        {
            if (pointerKey.Equals(keyboardLayout[i]))
            {
                ind = i;
                break;
            }
        }


        keys[0] = (KeyCode)(int)(keyboardLayout[ind][0]);
        keys[1] = (KeyCode)(int)(keyboardLayout[ind + 1][0]);

        return keys;
    }
}
