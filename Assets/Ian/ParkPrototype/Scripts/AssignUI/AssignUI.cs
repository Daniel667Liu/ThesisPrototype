using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignUI : MonoBehaviour
{
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.SetActive(!canvas.activeSelf);
        }
    }
}
