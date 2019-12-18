using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; 


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
}
