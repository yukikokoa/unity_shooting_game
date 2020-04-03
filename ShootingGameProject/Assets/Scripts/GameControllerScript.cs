using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public GameObject enemy;
    private int score;
    public Text scoreText;
    public Text replayText;
    private bool isGameOver;

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            Instantiate(
                enemy,
                new Vector3(Random.Range(-8f, 8f), transform.position.y, 0f),
                transform.rotation
                );
            yield return new WaitForSeconds(0.5f);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
        score = 0;
        UpdateScoreText();
        replayText.text = "";
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Spaceキーを押したらリプレイされるのを防ぐ。
        if(isGameOver == false)
        {
            return;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void AddScored(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        replayText.text = "Hit SPACE to replay!";
    }
}

