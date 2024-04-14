using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.PlayMusic("MenuSong");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
