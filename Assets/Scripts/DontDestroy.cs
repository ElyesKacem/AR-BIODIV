using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static GameObject[] objs;
  
    // Start is called before the first frame update
    private void Awake()
    {
        objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 2)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}
