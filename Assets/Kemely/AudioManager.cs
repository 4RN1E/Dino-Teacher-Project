using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource correctSound;
    public AudioSource incorrectSound;

    // Start is called before the first frame update
    void Start()
    {
        //background music
        if (backgroundMusic != null)
        {
            backgroundMusic.loop = true;
            backgroundMusic.Play(); 
           
        }
      
    }

    public void PlayCorrectSound()
    {
        if (correctSound != null)
        {
            correctSound.Play();
        }
    }

    public void PlayIncorrectSound()
    {
        if (incorrectSound != null)
        {
            incorrectSound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
