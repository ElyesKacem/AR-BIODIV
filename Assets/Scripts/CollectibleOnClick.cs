using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

public class CollectibleOnClick : MonoBehaviour
{
    public GameObject prefab;
    public bool isClicked = false;
    public float jumpForce = 1f;
    public float shrinkSpeed = 0.005f;

    private void Update()
    {
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
            Destroy(this.gameObject);
            CalculScript.collectiblesCount++;
            Debug.Log(CalculScript.collectiblesCount);
            Instantiate(prefab, transform.position, Quaternion.Euler(-90f,0f,0f));
        }
    }
}