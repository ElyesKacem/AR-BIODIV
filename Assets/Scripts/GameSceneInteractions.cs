using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneInteractions : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.tag == "toDestroy")
                {
                    hitInfo.transform.GetComponent<CollectibleOnClick>().isClicked = true;
                    Destroy(hitInfo.transform.GetComponent<BoxCollider>());
                }
                
            }
        }
    }
  
}
