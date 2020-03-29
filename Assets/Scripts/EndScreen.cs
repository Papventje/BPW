using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
