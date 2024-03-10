using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : Singleton<DeathUI>
{
    [SerializeField] GameObject deathPanel;

    
    void Start()
    {
        deathPanel.SetActive(false);
    }

    public void OpenDeath()
    {
        deathPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
