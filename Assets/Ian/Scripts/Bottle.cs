using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public float pourAngle;

    public Color color;

    public Transform bottleSprite;
    public Transform trail;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cup")
        {
            bottleSprite.eulerAngles = new Vector3(0, 0, pourAngle);

            trail.localPosition = new Vector3(-Mathf.Abs(trail.localPosition.x), trail.localPosition.y, trail.localPosition.z);
            trail.gameObject.SetActive(true);
            trail.GetComponent<SpriteRenderer>().color = color;

            collision.GetComponent<Liquid>().StartFilling(color);

            /*
            if (transform.position.x > collision.transform.position.x)
            {
                bottleSprite.eulerAngles = new Vector3(0, 0, pourAngle);
                trail.localPosition = new Vector3(-Mathf.Abs(trail.localPosition.x), trail.localPosition.y, trail.localPosition.z);
                trail.gameObject.SetActive(true);
            }
            else
            {
                bottleSprite.eulerAngles = new Vector3(0, 0, -pourAngle);
                trail.localPosition = new Vector3(Mathf.Abs(trail.localPosition.x), trail.localPosition.y, trail.localPosition.z);
                trail.gameObject.SetActive(true);
            }
            */
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Cup")
        {
            bottleSprite.eulerAngles = Vector3.zero;
            trail.gameObject.SetActive(false);

            collision.GetComponent<Liquid>().EndFilling();
        }
    }
}
