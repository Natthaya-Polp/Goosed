using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeMenu : MonoBehaviour
{
    public void Chapter1()
    {
        SceneManager.LoadScene("Chapter1");
    }

    public void EndlessMode()
    {
        SceneManager.LoadScene("EndlessMode");
    }
}
