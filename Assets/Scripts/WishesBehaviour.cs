using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WishesBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentWish;
    public int wish;
    private List<int> usedNumbers = new List<int> ();
    [SerializeField] private GameObject gameManager;
    private int cont = 1;

    // Start is called before the first frame update
    void Start()
    {
        ChangeWish();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.GetComponent<TimerBehaviour>().won)
        {
            if((gameManager.GetComponent<CardsCounter>().next) && cont != 6)
            {
                ChangeWish();
                gameManager.GetComponent<CardsCounter>().next = false;
                cont++;
            }
        } 
    }

    private void ChangeWish()
    {
        wish = Random.Range(1, 7);
        if(!usedNumbers.Contains(wish))
        {
            usedNumbers.Add(wish);
            currentWish.SetText("Desejo atual: " + wish);
        }
        else
        {
            ChangeWish();
        }
        gameManager.GetComponent<CardsCounter>().next = false;
    }
}
