using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public static Vector2 lastCheckPointPos = new Vector2(-9,-1);
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
            
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

        if(collision.transform.tag == "Chapter1End")
        {
            PlayerManager.isWin = true;
            //AudioManager.instance.Play("GameOver");
            gameObject.SetActive(false);
        }
    }
}
