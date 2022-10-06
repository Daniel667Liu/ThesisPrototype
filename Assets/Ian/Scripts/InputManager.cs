using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public LayerMask draggable;
    
    private GameObject currentSprite;
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, draggable);

            if (hit)
            {
                Debug.Log(hit.collider.name);
                currentSprite = hit.collider.gameObject;
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset = mousePos - currentSprite.transform.position;
            }
        }
        if (Input.GetMouseButton(0) && currentSprite != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentSprite.transform.position = mousePos - offset;
        }
        if (Input.GetMouseButtonUp(0))
        {
            currentSprite = null;
            offset = Vector3.zero;
        }

    }
}
