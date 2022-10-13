using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    
    [Header("BlackBoard")]
    public Vector3 blackBoardCameraPos;
    public float blackBoardCameraSize;
    public float blackBoardZoomSpeed;
    public float blackBoardSizeSpeed;
    public ChalkBoard chalkBoard;

    [Header("Curtains")]
    public Vector3 curtainsCameraPos;
    public float curtainsCameraSize;
    public float curtainsZoomSpeed;
    public float curtainsSizeSpeed;
    public CurtainControl curtains;

    [Header("Door")]
    public Vector3 doorCameraPos;
    public float doorCameraSize;
    public float doorZoomSpeed;
    public float doorSizeSpeed;
    public DoorLock door;

    [Header("Clock")]
    public Vector3 clockCameraPos;
    public float clockCameraSize;
    public float clockZoomSpeed;
    public float clockSizeSpeed;
    public Clock clock;

    private Vector3 startPos;
    private float startSize;
    private float zoomPosSpeed;
    private float zoomSizeSpeed;

    private bool zooming;
    private Vector3 targetPos;
    private float targetSize;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startSize = GetComponent<Camera>().orthographicSize;
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
                switch (hit.collider.gameObject.tag)
                {
                    case "PaperPlane":
                        // always listening, no need to zoom
                        break;
                    case "BlackBoard":
                        hit.collider.gameObject.GetComponent<ChalkBoard>().enabled = true;
                        zoom(blackBoardCameraPos, blackBoardCameraSize, blackBoardZoomSpeed, blackBoardSizeSpeed);
                        break;
                    case "Curtains":
                        hit.collider.gameObject.GetComponent<CurtainControl>().enabled = true;
                        zoom(curtainsCameraPos, curtainsCameraSize, curtainsZoomSpeed, curtainsSizeSpeed);
                        break;
                    case "DoorSelect":
                        hit.collider.gameObject.GetComponent<DoorLock>().enabled = true;
                        zoom(doorCameraPos, doorCameraSize, doorZoomSpeed, doorSizeSpeed);
                        break;
                    case "Clock":
                        hit.collider.gameObject.GetComponent<Clock>().selected = true;
                        zoom(clockCameraPos, clockCameraSize, clockZoomSpeed, clockSizeSpeed);
                        break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            unZoom();
        }


        if (zooming)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, zoomPosSpeed * Time.deltaTime);
            GetComponent<Camera>().orthographicSize = Mathf.MoveTowards(GetComponent<Camera>().orthographicSize, targetSize, zoomSizeSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.01f && Mathf.Abs(GetComponent<Camera>().orthographicSize - targetSize) < 0.01f)
            {
                zooming = false;
            }
        }
    }

    private void zoom(Vector3 _position, float _size, float _zoomPosSpeed, float _zoomSizeSpeed)
    {
        targetPos = _position;
        targetSize = _size;
        zoomPosSpeed = _zoomPosSpeed;
        zoomSizeSpeed = _zoomSizeSpeed;

        zooming = true;
    }

    private void unZoom()
    {
        disableAll();
        targetPos = startPos;
        targetSize = startSize;
        zooming = true;
    }

    private void disableAll()
    {
        // blackboard
        chalkBoard.enabled = false;

        curtains.enabled = false;
        curtains.StopCurtain();

        clock.selected = false;

        //others
    }
}
