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
        if(CalculScript.ReplaceblesCount==5){
           GameObject.Find("Canvas").transform.Find("DialogWin").gameObject.SetActive(true);
           GameObject.Find("WinSound").GetComponent<AudioSource>().Play();

        }
        
        //Instantiate(prefab, new Vector3(transform.position.x, -2f, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(prefab, new Vector3(transform.position.x, -1f, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
        //Instantiate(prefab, new Vector3(transform.position.x, -3f, transform.position.z), Quaternion.Euler(0f, 0f, 0f));

    }
}
