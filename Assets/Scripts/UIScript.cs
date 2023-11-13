using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Sprite turnOn;
    public Sprite turnOff;

    public Button musicButton;
    public Button soundButton;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {           
            soundButton.GetComponent<Image>().sprite = turnOff;
            
           
        }
        else
        {
            
            soundButton.GetComponent<Image>().sprite = turnOn;
            
        }
        if (PlayerPrefs.GetInt("music") == 0)
        {
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().mute = true;
            musicButton.GetComponent<Image>().sprite = turnOff;
        }
        else
        {
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().mute = false;
            musicButton.GetComponent<Image>().sprite = turnOn;            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void quit()
    {
        Application.Quit();
    }
    
    public void changeMusicState()
    {
        if(PlayerPrefs.GetInt("music")==0)
        {
            PlayerPrefs.SetInt("music", 1);
            musicButton.GetComponent<Image>().sprite = turnOn;
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().mute = false;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            musicButton.GetComponent<Image>().sprite = turnOff;
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().mute = true;
        }
    }
    public void changeSoundState()
    {
        if(PlayerPrefs.GetInt("sound")==0)
        {
            PlayerPrefs.SetInt("sound", 1);
            soundButton.GetComponent<Image>().sprite = turnOn;         
        }
        else
        {
            PlayerPrefs.SetInt("sound", 0);
            soundButton.GetComponent<Image>().sprite = turnOff;            
        }
    }
    
}
