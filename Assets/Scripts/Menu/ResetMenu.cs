using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResetMenu : MonoBehaviour
{
    public TextMeshProUGUI hiscoreText;
    public TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);
        hiscore = 0f;
        hiscore = PlayerPrefs.GetFloat("hiscore", hiscore);
        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");

        float coinCount = PlayerPrefs.GetFloat("coinCount", 0);
        coinCount = 0f;
        coinCount = PlayerPrefs.GetFloat("coinCount", coinCount);
        coinText.text = Mathf.FloorToInt(coinCount).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
