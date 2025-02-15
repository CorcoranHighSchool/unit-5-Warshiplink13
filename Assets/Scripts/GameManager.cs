using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    public static GameManager instance;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    private int score;
    public TextMeshProUGUI scoreText;
    public bool isGameActive {get; private set;}
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameOver()

    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void ResetGame()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore( int scoreToAdd)

    {
        score += scoreToAdd;
        scoreText.text = "Score" + score;
    }
    IEnumerator SpawnTarget()

    {
        while (isGameActive)

        {
            yield return new WaitForSeconds(spawnRate);
            //spawn target
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;        
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }
}

