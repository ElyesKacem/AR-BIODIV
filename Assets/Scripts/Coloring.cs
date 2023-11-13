using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
//using UnityEngine.UI;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class Coloring : MonoBehaviour
{
    private Camera mainCamera;
    public Texture2D brushTexture;
    public float brushSize = 10f;
    public Color brushColor = Color.red;

    private RaycastHit hitInfo;
    private Renderer rend;
    private Texture2D canvasTexture;
    private Vector2 storedUV;
    private ARRaycastManager aRRaycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Vector2 touchPosition = default;

    void Start()
    {
        rend = GetComponent<Renderer>();
        canvasTexture = new Texture2D(1024, 1024);
        canvasTexture.wrapMode = TextureWrapMode.Clamp;
        rend.material.mainTexture = canvasTexture;
        mainCamera = Camera.main;
    }
    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }
    public void coloring()
    {
        //Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        //Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    Destroy(hitObject.transform.gameObject);
                }
            }
        }


        //RaycastHit hitInfo;

        //if (Physics.Raycast(mainCamera.transform.position,mainCamera.transform.forward, out hitInfo))
        //{
        //    //Debug.Log(hitInfo.transform.name);

        //    if (hitInfo.transform == transform)
        //    {

        //        //Paint(hitInfo.textureCoord);
        //        hitInfo.transform.GetComponent<Coloring>().Paint(hitInfo.textureCoord);
        //    }
        //}
    }
    //private void OnEnable()
    //{
    //    EnhancedTouch.TouchSimulation.Enable();
    //    EnhancedTouch.EnhancedTouchSupport.Enable();
    //    EnhancedTouch.Touch.onFingerDown += FingerDown;
    //}
    //private void OnDisable()
    //{
    //    EnhancedTouch.TouchSimulation.Disable();
    //    EnhancedTouch.EnhancedTouchSupport.Disable();
    //    EnhancedTouch.Touch.onFingerDown -= FingerDown;
    //}
    //private void FingerDown(EnhancedTouch.Finger finger)
    //{
    //    if (finger.index != 0) return;
    //    if (aRRaycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
    //    {
            
    //    }
    //}
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo))
        //    {
        //        Debug.Log(hitInfo.transform.name);
        //        if (hitInfo.transform == transform)
        //        {
        //            Debug.Log(hitInfo.transform.name);
        //            Debug.Log("cccccccccccccccccccccccccccc",transform);
        //            Debug.Log(hitInfo.textureCoord);
        //            Paint(hitInfo.textureCoord);
        //        }
        //    }
        //}





        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0); // Get the first touch (you can modify this to support multiple touches)

        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        //Ray ray = mainCamera.ScreenPointToRay(touch.position);
        //        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hitInfo))
        //        {
        //            //Debug.Log(hitInfo.transform.name);

        //            if (hitInfo.transform == transform)
        //            {

        //                //Paint(hitInfo.textureCoord);
        //                hitInfo.transform.GetComponent<Coloring>().Paint(hitInfo.textureCoord);
        //            }
        //        }
        //    }
        //}


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    Destroy(hitObject.transform.gameObject);
                }
            }
        }

    }

    void Paint(Vector2 uv)
    {
        int x = (int)(uv.x * canvasTexture.width);
        int y = (int)(uv.y * canvasTexture.height);

        for (int i = -Mathf.RoundToInt(brushSize); i < Mathf.RoundToInt(brushSize); i++)
        {
            for (int j = -Mathf.RoundToInt(brushSize); j < Mathf.RoundToInt(brushSize); j++)
            {
                if (x + i >= 0 && x + i < canvasTexture.width && y + j >= 0 && y + j < canvasTexture.height)
                {
                    canvasTexture.SetPixel(x + i, y + j, brushColor);
                }
            }
        }
        canvasTexture.Apply();
    }
}