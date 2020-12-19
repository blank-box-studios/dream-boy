using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [Header("Enemy Spawning")]
    public GameObject[] goblin;
    public float spawnRate;
    public float waitTillNextbullet;

    [Header("Score Tracking")]
    public float score;
    public GameObject scoreBox;
    public bool playerDead;

    [Header("UI")]
    public Text scoreText;
    public Text scoreSBText;
    //public Text highscoreSBText;




    


    // Start is called before the first frame update
    void Start()
    {
        //if (PlayerPrefs.GetFloat("HighScore") == 0)
        //{
        //    PlayerPrefs.SetFloat("HighScore", 0);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTillNextbullet <= 0)
        {
            Instantiate(goblin[Random.Range(0,2)], new Vector2(0.805f,- 0.209f), transform.rotation);
            waitTillNextbullet = 1;
        }
        waitTillNextbullet -= Time.deltaTime * spawnRate;


        if (!playerDead)
        {
            score += 1 * Time.deltaTime;
        }
       




        scoreText.text = Mathf.Round(score).ToString();

        scoreSBText.text = Mathf.Round(score).ToString();

        //highscoreSBText.text = Mathf.Round(PlayerPrefs.GetInt("HighScore")).ToString();




        
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void endGame()
    {
        playerDead = true;
        scoreBox.SetActive(true);

        //if (PlayerPrefs.GetFloat("HighScore") == 0)
        //{
        //    PlayerPrefs.SetFloat("HighScore", 0);
        //}

        //if (score > PlayerPrefs.GetFloat("HighScore"))
        //{
        //    PlayerPrefs.SetFloat("HighScore", score);
        //}
    }

    
}
