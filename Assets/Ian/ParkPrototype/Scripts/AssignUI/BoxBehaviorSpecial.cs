using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoxBehaviorSpecial : EventTrigger
{
    private Box box;

    private Vector2 offset;
    private Transform screenshot;
    private Vector3 prevMousePos;

    private bool shown;

    // Start is called before the first frame update
    void Start()
    {
        screenshot = transform.parent.GetChild(0);
        box = GetComponent<Box>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        if (!shown)
        {
            screenshot.localScale = Vector3.one * 1.15f;
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        screenshot.localScale = Vector3.one * 1f;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        for (int i=1; i<transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Image>().color = new Color(transform.GetChild(i).GetComponent<Image>().color.r, transform.GetChild(i).GetComponent<Image>().color.g, transform.GetChild(i).GetComponent<Image>().color.b, 0.78f);
        }
        screenshot.localScale = Vector3.one * 1f;
        shown = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Vector3 centerPos = box.CheckInput();

        if (centerPos.x != -1001)
        {
            transform.position = new Vector3(centerPos.x, centerPos.y, centerPos.z);
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //offset = mousePos - GetComponent<RectTransform>().localPosition;
        prevMousePos = Input.mousePosition;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log(Input.mousePosition);
        //Debug.Log(mousePos);
        //GetComponent<RectTransform>().position = new Vector3(mousePos.x, mousePos.y, -9) - new Vector3(offset.x, offset.y, 0f);
        GetComponent<RectTransform>().localPosition += (Input.mousePosition - prevMousePos) * 1920f / Screen.width;
        prevMousePos = Input.mousePosition;
    }
}
