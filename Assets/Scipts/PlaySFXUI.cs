using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFXUI : MonoBehaviour
{
    public AudioSource soundButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySfxButton()
    {
        soundButton.Play();
    }
}
