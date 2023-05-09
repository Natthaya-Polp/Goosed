using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    public TextMeshProUGUI hiscoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        float hiscore = PlayerPrefs.GetFloat("hiscore");
        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
