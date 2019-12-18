using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsBehaviour : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private float delay2;
    public Animator animator;
    private int cardsUp = 0;
    public GameObject cardsCounter;
    public bool canClick = false;
    public GameObject wishesManager;
    [SerializeField]private int combination;

    void Start()
    {
         StartCoroutine(TurnCardsDown());
    }

    void Update()
    {
        cardsUp = cardsCounter.GetComponent<CardsCounter>().counter;
        if(cardUp == 3)
        {
            WrongCombination();
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
            if(wishesManager.GetComponent<WishesBehaviour>().wish != combination)
            {
                animator.SetTrigger("Turn Down");
            }
        }
    }

    IEnumerator WrongCombination()
    {
            yield return new WaitForSeconds(delay2);
            animator.SetTrigger("Turn Down");
    }

}
