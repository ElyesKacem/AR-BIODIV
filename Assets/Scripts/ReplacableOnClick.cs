using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        GameObject.Find("SuccessSound").GetComponent<AudioSource>().Play();
        GameObject.Find("finalScore").GetComponent<TMP_Text>().text = ((CalculScript.collectiblesCount+CalculScript.ReplaceblesCount)*10).ToString();
        GameObject.Find("progressBar").GetComponent<Slider>().value = (CalculScript.collectiblesCount+CalculScript.ReplaceblesCount)*10;
        GameObject.Find("plantedTreeScore").GetComponent<TMP_Text>().text = CalculScript.ReplaceblesCount.ToString();
        if(CalculScript.collectiblesCount+CalculScript.ReplaceblesCount==10){
            GameObject.Find("DialogWin").SetActive(true);
        }
        
        Instantiate(prefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
    }
}
