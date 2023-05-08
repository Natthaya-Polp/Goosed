using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeMenu : MonoBehaviour
{
    public void StoryMode()
    {
        SceneManager.LoadScene("StoryMode");
    }

    public void EndlessMode()
    {
        SceneManager.LoadScene("EndlessMode");
    }
}
