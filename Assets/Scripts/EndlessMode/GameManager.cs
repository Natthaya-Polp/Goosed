using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 3f;
    public float gameSpeedIncrease = 0.02f;
    public float gameSpeed { get; private set; }

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public Button backButton;

    private PlayerEndless player;
    private Spawner spawner;

    private float score;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        } 
        else 
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) 
        {
            Instance = null;
        }
    }

    public void Start()
    {
        player = FindObjectOfType<PlayerEndless>();
        spawner = FindObjectOfType<Spawner>();

        NewGame();
        UpdateCoins();
    }

    public void NewGame()
    {
        EndlessObstacle[] obstacles = FindObjectsOfType<EndlessObstacle>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        UpdateHiscore();
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);

        UpdateHiscore();
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);
        hiscore = PlayerPrefs.GetFloat("hiscore");
        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }

    public void UpdateCoins()
    {
        float coinCount = PlayerPrefs.GetFloat("coinCount");
        PlayerPrefs.SetFloat("coinCount", coinCount);
        coinText.text = Mathf.FloorToInt(coinCount).ToString();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
