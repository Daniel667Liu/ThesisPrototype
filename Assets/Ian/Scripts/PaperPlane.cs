using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlane : MonoBehaviour
{
    public float throwThreshold;

    private bool selected;
    private Vector3 startPos;
    private Vector3 prevPos;
    private Vector3 prevMousePos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "PaperPlane")
                {
                    // grabbed paperplane
                    selected = true;
                } 
            }
        }

        if (selected)
        {
            Vector3 mouseScreenPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 delta = mousePos - startPos;
            transform.position = startPos + delta * 0.05f;

            Debug.Log(Screen.width);
            if (prevPos != Vector3.zero && Vector3.Distance(transform.position, prevPos) > throwThreshold / (Screen.width / 800f))
            {

                Debug.Log(Input.mousePosition - prevMousePos);
                // if the direction is also correct
                if (Vector3.Angle(Input.mousePosition - prevMousePos, new Vector3(1.4f, 1f, 0)) < 30f) 
                {
                    Debug.Log("throw");
                    selected = false;

                    // trigger animation
                }
            }

            prevPos = transform.position;
            prevMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && selected)
        {
            selected = false;
            transform.position = startPos;
        }
    }


}
