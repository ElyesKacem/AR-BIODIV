using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneInteractions : MonoBehaviour
{
    public GameObject prefab;
    public GameObject FoxAnimated;
    public void permutSpawn()
    {
        PlaceItem.spawn = true;
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
    public void playAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void replaceFox()
    {
        GameObject oldFox = GameObject.Find("Fox");
        Destroy(oldFox);
        GameObject newFox = Instantiate(FoxAnimated, oldFox.transform.position,oldFox.transform.rotation);
        newFox.transform.localScale=oldFox.transform.localScale;
    }

    public void setFoxTrue()
    {
        GameObject.Find("Game Plane").transform.Find("Fox").gameObject.SetActive(true);
    }
    public void setInteractableTrue()
    {
        
        GameObject.Find("Game Plane").transform.Find("interactable").gameObject.SetActive(true);
       
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
                if (hitInfo.transform.tag == "toReplace")
                {
                    hitInfo.transform.GetComponent<ReplacableOnClick>().isClicked = true;
                    Destroy(hitInfo.transform.GetComponent<BoxCollider>());
                }

            }
        }
    }
}
