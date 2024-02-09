using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    private PlayerController playerContoller;
    private Collisions collisionsScript;
    private SpawnManager spawnManagerScript;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public GameObject gameOverPanel;
    public GameObject heartsPanel;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public GameObject gameMenuPanel;

    // Start is called before the first frame update
    void Start()
    {
       spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
       playerContoller = GameObject.Find("Player").GetComponent<PlayerController>();
       collisionsScript = GameObject.Find("Player").GetComponent<Collisions>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        collisionsScript.gameOver = false;
    }
    public void StartGame(int difficulty)
    {
        if (gameMenuPanel.activeSelf)
        {
            heartsPanel.SetActive(false);
        }

        spawnManagerScript.repeatRate /= difficulty;
        collisionsScript.gameOver = false;
        spawnManagerScript.StartSpawningFood();
        UpdateScore(0);
        gameMenuPanel.SetActive(false);
    }
}
