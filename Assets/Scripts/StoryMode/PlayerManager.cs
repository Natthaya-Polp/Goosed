using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;

    public static Vector2 lastCheckPointPos = new Vector2(-9,-1);

    //public static int numberOfCoins;
    //public TextMeshProUGUI coinsText;

    //public CinemachineVirtualCamera VCam;
    //public GameObject[] playerPrefabs;
    //int characterIndex;

    private void Awake()
    {
    //    characterIndex =  PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    //    VCam.m_Follow = player.transform;
    //    numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;

    }

    void Update()
    {
    //    coinsText.text = numberOfCoins.ToString() ;
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}