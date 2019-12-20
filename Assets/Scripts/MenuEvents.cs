using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    [SerializeField] private GameObject levelChanger;
    [SerializeField] private GameObject manual;
    [SerializeField] private AudioSource button;

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.S)))
        {
            manual.SetActive(false);
        }
    }

    public void GoToGame()
    {
        button.Play();
        levelChanger.GetComponent<LevelChanger>().FadeToLevel(1);
    }

    public void HowToPlay()
    {
        button.Play();
        manual.SetActive(true);
    }

    public void QuitGame()
    {
        button.Play();
        levelChanger.GetComponent<LevelChanger>().EndGame();
    }

    public void GoToMainMenu()
    {
         button.Play();
         levelChanger.GetComponent<LevelChanger>().FadeToLevel(0);
    }

    
}
