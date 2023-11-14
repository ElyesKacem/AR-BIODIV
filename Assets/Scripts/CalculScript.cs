using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculScript : MonoBehaviour
{
    public static int archivment;
    // Start is called before the first frame update
    void Start()
    {
        archivment = 0;
    }

    public void incrementArchivment()
    {
        archivment += 1;
    }
    public void turnOnEraser()
    {
        ColoringBehaviour.eraser = true;
    }
}
