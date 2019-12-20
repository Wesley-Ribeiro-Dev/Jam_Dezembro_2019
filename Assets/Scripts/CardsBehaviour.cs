using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsBehaviour : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private float delay2;
    [SerializeField] private float delay3;
    [SerializeField] private float delay4;
    [SerializeField] private Animator animator;
    private int cardsUp = 0;
    [SerializeField] private GameObject gameManager;
    public bool canClick = false;
    [SerializeField]private int combination;
    [SerializeField] private GameObject Wrong;
    [SerializeField] private GameObject Right;
    public bool wasClicked = false;
    public bool correct = false;
    private List<int> usedCorrectCombinations = new List<int> ();
    private List<int> usedWrongCombinations = new List<int> ();
    public bool useScroll = false; 
    [SerializeField] private AudioSource cardFlip;
    [SerializeField] private AudioSource success;
    [SerializeField] private AudioSource failure;
    void Start()
    {
         StartCoroutine(TurnCardsDown());
    }

    void Update()
    {
        if(gameManager.GetComponent<TimerBehaviour>().timeEnded)
        {
            canClick = false;
        }

        cardsUp = gameManager.GetComponent<CardsCounter>().counter;
        if((gameManager.GetComponent<CardsCounter>().counter == 3) && !gameManager.GetComponent<CardsCounter>().rightCombination)
        {
            StartCoroutine(WrongCombination());
        }
        if((gameManager.GetComponent<CardsCounter>().counter == 3) && gameManager.GetComponent<CardsCounter>().rightCombination)
        {
            StartCoroutine(CorrectCombination());
        }
    }

    IEnumerator TurnCardsDown()
    {
            yield return new WaitForSeconds(delay);
            animator.SetTrigger("Time to start");
            cardFlip.Play();
            canClick = true;
            useScroll = true;
    }

    private void OnMouseDown() 
    {
        if((cardsUp < 3) && (canClick) && !wasClicked && gameManager.GetComponent<ScrollBehaviour>().scrollOff)
        {
            animator.SetTrigger("Turn Up");
            cardFlip.Play();
            gameManager.GetComponent<CardsCounter>().counter++;
            if(gameManager.GetComponent<WishesBehaviour>().wish != combination)
            {
                gameManager.GetComponent<CardsCounter>().rightCombination = false;
                gameManager.GetComponent<CardsCounter>().wrongCombination++;
            }
            else if((gameManager.GetComponent<CardsCounter>().wrongCombination == 0) && (gameManager.GetComponent<WishesBehaviour>().wish == combination))
            {
                gameManager.GetComponent<CardsCounter>().rightCombination = true;
            }
            wasClicked = true;
        }
        
    }

    IEnumerator WrongCombination()
    {   
        if(!usedWrongCombinations.Contains(combination))
        {
            usedWrongCombinations.Add(combination);
            canClick = false;
            yield return new WaitForSeconds(delay2);
            if(!correct)
            {
                animator.SetTrigger("Turn Down");
                cardFlip.Play();
                Wrong.SetActive(true);
                failure.Play();
                gameManager.GetComponent<CardsCounter>().counter = 0;
                gameManager.GetComponent<CardsCounter>().wrongCombination = 0;
                if(combination != gameManager.GetComponent<WishesBehaviour>().wish)
                {
                    gameManager.GetComponent<TimerBehaviour>().DecreaseTime();
                }
                yield return new WaitForSeconds(delay3);
                animator.ResetTrigger("Turn Down");
                wasClicked = true;
                yield return new WaitForSeconds(delay3);
                canClick = true;
                wasClicked = false;
                yield return new WaitForSeconds(delay4);
                Wrong.SetActive(false);
                usedWrongCombinations.Clear();
            } 
        }
    }

    IEnumerator CorrectCombination()
    {
        if(!usedCorrectCombinations.Contains(combination))
        {
            usedCorrectCombinations.Add(combination);
            canClick = false;
            yield return new WaitForSeconds(delay2);
            Right.SetActive(true);
            success.Play();
            gameManager.GetComponent<CardsCounter>().counter = 0;
            gameManager.GetComponent<CardsCounter>().wrongCombination = 0;
            if(combination == gameManager.GetComponent<WishesBehaviour>().wish)
            {
                correct = true;
                gameManager.GetComponent<TimerBehaviour>().IncreaseTime();
                gameManager.GetComponent<TimerBehaviour>().cont3++;
            }
            yield return new WaitForSeconds(delay3);
            animator.ResetTrigger("Turn Down");
            wasClicked = true;
            yield return new WaitForSeconds(delay3);
            canClick = true;
            wasClicked = false;
            yield return new WaitForSeconds(delay4);
            Right.SetActive(false);
            gameManager.GetComponent<CardsCounter>().next = true;
            usedCorrectCombinations.Clear();
        }
    }
}
