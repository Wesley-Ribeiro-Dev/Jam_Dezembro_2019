using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; 
using UnityEngine.SceneManagement;


public class TimerBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    public float time;
    public GameObject mold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= 0)
        {
            TimeEnded();
        }
        TimeLeft();
        if(mold.GetComponent<CardsBehaviour>().canClick)
            {
              time -= Time.deltaTime;
           }
    }

    private void TimeLeft()
    {
        timer.SetText("Tempo restante: " + Math.Round(time, 0));
    }

    private void TimeEnded()
    {
        SceneManager.LoadScene("Game Over");
    }

}
