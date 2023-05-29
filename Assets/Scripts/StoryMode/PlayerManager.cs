using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    
    public static bool isGameOver;
    public static bool isWin;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    public GameObject chapterEndScreen;

    public static Vector2 lastCheckPointPos = new Vector2(-9,-1);

    AudioSource audioClip;

    //public static int numberOfCoins;
    //public TextMeshProUGUI coinsText;

    //public CinemachineVirtualCamera VCam;
    //public GameObject[] playerPrefabs;
    //int characterIndex;

    private void Awake()
    {
    //    characterIndex =  PlayerPrefs.GetInt("SelectedCharacter", 0);
        
    //    VCam.m_Follow = player.transform;
    //    numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        audioClip = GetComponent <AudioSource>();

        isGameOver = false;
        isWin = false;

        //Update Coins
        float coinCount = PlayerPrefs.GetFloat("coinCount");
        coinText.text = Mathf.FloorToInt(coinCount).ToString();
    }

    void Update()
    {
    //    coinsText.text = numberOfCoins.ToString() ;
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }

        if (isWin)
        {
            chapterEndScreen.SetActive(true);
            audioClip.Play();
            isWin = false;
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