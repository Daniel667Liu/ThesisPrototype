using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class Bottle : MonoBehaviour
{
    public float pourAngle;

    public Color color;

    public float pourSpeed;
    public ObiEmitter emitter;
    public Transform bottleSprite;
    public Transform trail;

    private InputManager im;

    // Start is called before the first frame update
    void Start()
    {
        im = GameObject.Find("InputManager").GetComponent<InputManager>();
        emitter.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (im.currentBottle == this)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Pour();
            }
            if (Input.GetMouseButtonUp(1))
            {
                unPour();
            }
        }
    }

    public void Pour()
    {
        bottleSprite.eulerAngles = new Vector3(0, 0, pourAngle);
        emitter.speed = pourSpeed;

        //trail.localPosition = new Vector3(-Mathf.Abs(trail.localPosition.x), trail.localPosition.y, trail.localPosition.z);
        //trail.gameObject.SetActive(true);
        //trail.GetComponent<SpriteRenderer>().color = color;

        //collision.GetComponent<Liquid>().StartFilling(color);
    }

    public void unPour()
    {
        bottleSprite.eulerAngles = Vector3.zero;
        emitter.speed = 0f;

        //trail.gameObject.SetActive(false);

        //collision.GetComponent<Liquid>().EndFilling();
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cup")
        {
            Pour();

            /**
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
            /
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Cup")
        {
            unPour();
        }
    }
    */
}
