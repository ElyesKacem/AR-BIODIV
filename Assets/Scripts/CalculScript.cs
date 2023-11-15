using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculScript : MonoBehaviour
{
    public static int collectiblesCount=0;
    // Start is called before the first frame update
   

    public void incrementCollectiblesCount()
    {
        collectiblesCount += 1;
    }
    public void turnOnEraser()
    {
        ColoringBehaviour.eraser = true;
    }
}
