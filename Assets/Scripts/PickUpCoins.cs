using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpCoins : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public AudioClip coinSound;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            float coinCount = PlayerPrefs.GetFloat("coinCount");
            AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
            coinCount++;
            //coinText.text = coinCount.ToString();
            PlayerPrefs.SetFloat("coinCount", coinCount);
            coinText.text = Mathf.FloorToInt(coinCount).ToString();

            Destroy(other.gameObject);
        }
    }
}
