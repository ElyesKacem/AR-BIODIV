using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class SpawnOnceBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private Vector2 touchPosition;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }
    bool GetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount>0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if ( !GetTouchPosition(out touchPosition))
        {
            return;
        }
        if (aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            foreach (ARRaycastHit hit in hits)
            {
                Pose pose = hit.pose;

                if (prefab == null)
                {
                    prefab = Instantiate(prefab, pose.position, pose.rotation);

                }
                else
                {
                    return;
                }
            }
        }
    }
}
