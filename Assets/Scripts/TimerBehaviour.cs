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
    [SerializeField] private GameObject mold;
    
    [SerializeField] private GameObject levelChanger;
    public bool timeEnded = false;
    private int cont = 0;
    private int cont1 = 0;
    private int cont2 = 0;
    public int cont3 = 0;
    [SerializeField] private GameObject TimeUp;
    [SerializeField] private int delay;
    [SerializeField] private int delay2;
    [SerializeField] private GameObject Congratulations;
    public bool won = false;

    // Update is called once per frame
    void Update()
    {
        if(cont1 == 60)
        {
            StartCoroutine(GameWon());
        }

        if(time <= 0.1)
        {
            time = 0;
        }

        if(time <= 0.1)
        {
            timeEnded = true;
            StartCoroutine(TimeEnded());
        }
        TimeLeft();
        if((mold.GetComponent<CardsBehaviour>().canClick) && (!timeEnded))
            {
              time -= Time.deltaTime;
           }
    }

    private void TimeLeft()
    {
        timer.SetText("Tempo restante: " + Math.Round(time, 0));
    }

    IEnumerator TimeEnded()
    {
        yield return new WaitForSeconds(delay2);
        TimeUp.SetActive(true);
        yield return new WaitForSeconds(delay);
        levelChanger.GetComponent<LevelChanger>().FadeToLevel(2);
    }

    IEnumerator GameWon()
    {
        won = true;
        yield return new WaitForSeconds(delay2);
        Congratulations.SetActive(true);
        yield return new WaitForSeconds(delay);
        levelChanger.GetComponent<LevelChanger>().FadeToLevel(3);
    }

    public void IncreaseTime()
    {
        cont++;
        if(cont == 1)
        {
            time += 15;
            cont1 += 10;
        }
        if(cont == 3)
        {
            cont = 0;
        }
    }

    public void DecreaseTime()
    {
        cont2++;
        if(cont2 == 1)
        {
            time -= 10;
        }
        if((cont2 - cont3) == 18 - cont3)
        {
            cont2 = 0;
        }
    }

}
