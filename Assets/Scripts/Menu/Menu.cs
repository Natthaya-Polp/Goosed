using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI hiscoreText;
    public TextMeshProUGUI coinText;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        float hiscore = PlayerPrefs.GetFloat("hiscore");
        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");

        float coinCount = PlayerPrefs.GetFloat("coinCount");
        coinText.text = Mathf.FloorToInt(coinCount).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
