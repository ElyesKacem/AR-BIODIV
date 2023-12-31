using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(requiredComponent:typeof(ARRaycastManager),requiredComponent2:typeof(ARPlaneManager))]
public class PlaceItem : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    public static bool spawn = false;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool isSpawned = false;

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }
    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;
        if (!isSpawned && spawn && aRRaycastManager.Raycast(finger.currentTouch.screenPosition,hits,TrackableType.PlaneWithinPolygon)){
            foreach(ARRaycastHit hit in hits)
            {
                Pose pose = hit.pose;
                GameObject obj = Instantiate(prefab, pose.position, pose.rotation);
                GameObject.Find("SuccessSound").GetComponent<AudioSource>().Play();
                //GameObject.Find("DialogColoringQuest").SetActive(true);
                GameObject.Find("Canvas").transform.Find("DialogColoringQuest").gameObject.SetActive(true);

                isSpawned = true;
            }
        }
    }
}
