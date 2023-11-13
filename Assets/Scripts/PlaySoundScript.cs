using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundScript : MonoBehaviour
{
    public void playSound()
    {
        if (PlayerPrefs.GetInt("sound") != 0)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
