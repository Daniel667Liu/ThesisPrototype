using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DogWalkerBox : Box
{
    public DogPeopleInput dogPeopleInput;

    public LayerMask keyLayer;
    private Transform pointer;

    private string[] validBotLeftKeys = new string[] {"`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=",
     "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "\\",
     "a", "s", "d", "f", "g", "h", "j", "k", "l", ";", "'",
     "z", "x", "c", "v", "b", "n", "m", ",", ".", "/", "down", "up", "left", "right"};

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
                KeyCode key = getKey(hit.collider.name);
                if (dogPeopleInput != null) dogPeopleInput.AssignKeys(key);
                return hit.collider.transform.position + (transform.position - pointer.position);
            }
        }

        return new Vector3(-1001, 0, 0);
    }

    public KeyCode getKey(string pointerKey)
    {
        int ind = -1;
        for (int i = 0; i < keyboardLayout.Length; i++)
        {
            if (pointerKey.Equals(keyboardLayout[i]))
            {
                ind = i;
                break;
            }
        }

        if (pointerKey.Equals("up")) return KeyCode.UpArrow;
        if (pointerKey.Equals("down")) return KeyCode.DownArrow;
        if (pointerKey.Equals("left")) return KeyCode.LeftArrow;
        if (pointerKey.Equals("right")) return KeyCode.RightArrow;

        return (KeyCode)(int)(keyboardLayout[ind][0]);
    }
}
