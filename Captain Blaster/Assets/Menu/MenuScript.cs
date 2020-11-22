using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
       SceneManager.LoadScene("gameplay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
