using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleOnClick : MonoBehaviour
{
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
        }
    }
}