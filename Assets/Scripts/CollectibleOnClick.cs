using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

public class CollectibleOnClick : MonoBehaviour
{
    public GameObject prefab;
    private bool isClicked = false;
    private float jumpForce = 1f;
    private float shrinkSpeed = 0.005f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform == transform)
                {
                    isClicked = true;
                }
            }
        }
        if (isClicked)
        {
            ShrinkAndDisappear();
        };
    }

    private void ShrinkAndDisappear()
    {
        transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed);

        if (transform.localScale.x <= 0f)
        {
            Destroy(gameObject);
            Instantiate(prefab, transform.position, Quaternion.Euler(-90f,0f,0f));
        }
    }
}