using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            
            if(HealthManager.health <=0)
            {
                PlayerManager.isGameOver = true;
                //AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }
        }

        if(collision.transform.tag == "Fall")
        {
            PlayerManager.isGameOver = true;
            //AudioManager.instance.Play("GameOver");
            gameObject.SetActive(false);
        }
    }
}
