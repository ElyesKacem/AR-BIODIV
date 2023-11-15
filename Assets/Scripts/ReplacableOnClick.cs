using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacableOnClick : MonoBehaviour
{
    public GameObject prefab;
    public bool isClicked;

    private void Update()
    {
        if (isClicked)
        {
            RemoveAndReplace();
        };
    }

    private void RemoveAndReplace()
    {
        Destroy(this.gameObject);
        CalculScript.ReplaceblesCount++;
        Debug.Log(CalculScript.ReplaceblesCount);
        Instantiate(prefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
    }
}
