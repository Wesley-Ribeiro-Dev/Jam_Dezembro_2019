using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsBehaviour : MonoBehaviour
{
    [SerializeField] private float delay;
    public Animator animator;
    private int cardsUp = 0;
    public GameObject cardsCounter;
    private bool canClick = false;

    void Start()
    {
         StartCoroutine(TurnCardsDown());
    }

    void Update()
    {
        Debug.Log(cardsUp);
         cardsUp = cardsCounter.GetComponent<CardsCounter>().counter;
         if(cardsUp == 3)
         {
             animator.SetTrigger("Turn Down");
         }
    }

    IEnumerator TurnCardsDown()
    {
            yield return new WaitForSeconds(delay);
            animator.SetTrigger("Time to start");
            canClick = true;
    }

    private void OnMouseDown() 
    {
        if((cardsUp < 3) && (canClick))
        {
            animator.SetTrigger("Turn Up");
            cardsCounter.GetComponent<CardsCounter>().counter++;
        }
    }
}
