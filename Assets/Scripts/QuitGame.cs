using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    [SerializeField] private GameObject levelChanger;
    [SerializeField] private GameObject dio;
 
    public void CloseGame()
    {
        levelChanger.GetComponent<LevelChanger>().EndGame();
    }

    public void Wryyy()
    {
        dio.SetActive(true);
    }
}
