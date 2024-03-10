using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    public void OnSelectedStart()
    {
        SceneManager.LoadScene("Opening");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
