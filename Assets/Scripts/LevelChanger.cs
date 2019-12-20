using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int delay;
    private int levelToLoad;

    private void FixedUpdate() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame();
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("Fade Out");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void EndGame()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator QuitGame()
    {
        animator.SetTrigger("Fade Out");
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }
}
