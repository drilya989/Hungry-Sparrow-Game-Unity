using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public bool gameOver = false;
    public int score = 0;
    public int livesleft = 3;
    private GameManager gameManagerScript;
    public AudioClip sfxBadFood;
    public AudioClip sfxGoodFood;
    public AudioClip sfxSlayFood;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.gameMenuPanel.activeSelf)
        {
            gameManagerScript.heartsPanel.SetActive(false);
        }
        else
        {
             HeartSystem();
        }
    }
    //odejmuje zycia przy zjedzeniu zlego jedzenia i dodaje punkty za dobre jedzenie
   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "badFood")
        {
            Destroy(other.gameObject);
            livesleft--;
            playerAudio.PlayOneShot(sfxBadFood, 1.0f);
            
        } else if (other.gameObject.tag == "goodFood")
        {
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(sfxGoodFood, 1.0f);
            gameManagerScript.UpdateScore(1);

        } else if (other.gameObject.tag == "slayFood")
        {
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(sfxSlayFood, 1.0f);
            gameManagerScript.UpdateScore(4);
            
        }
        
    }

    void HeartSystem()
    {
        if (livesleft == 0)
        {
            gameOver = true;
            gameManagerScript.heartsPanel.SetActive(false);
            Debug.Log("GAME OVER");
            gameManagerScript.GameOver();

        }
        else if (livesleft == 3)
        {
            gameManagerScript.heartsPanel.SetActive(true);
        }
        else if (livesleft == 2)
        {
            gameManagerScript.heart1.gameObject.SetActive(false);
        }
        else if (livesleft == 1)
        {
            gameManagerScript.heart2.gameObject.SetActive(false);
        }
    }
}
