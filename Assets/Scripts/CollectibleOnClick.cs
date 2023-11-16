using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
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
            GameObject.Find("finalScore").GetComponent<TMP_Text>().text = ((CalculScript.collectiblesCount+CalculScript.ReplaceblesCount)*10).ToString();
            GameObject.Find("progressBar").GetComponent<Slider>().value = (CalculScript.collectiblesCount + CalculScript.ReplaceblesCount) * 10;
            GameObject.Find("destroyedValue").GetComponent<TMP_Text>().text = CalculScript.collectiblesCount.ToString();
            
            Instantiate(prefab, new Vector3(transform.position.x,0f,transform.position.z), Quaternion.Euler(-90f,0f,0f));    
        }
    }
}