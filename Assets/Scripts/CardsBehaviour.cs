using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsBehaviour : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private float delay2;
    [SerializeField] private float delay3;
    [SerializeField] private float delay4;
    public Animator animator;
    private int cardsUp = 0;
    public GameObject gameManager;
    public bool canClick = false;
    [SerializeField]private int combination;
    public GameObject Wrong;
    public GameObject Right;
    private bool wasClicked = false;
    public bool correct = false;
    private List<int> usedCombinations = new List<int> ();
    public bool useScroll = false; 

    void Start()
    {
         StartCoroutine(TurnCardsDown());
    }

    void Update()
    {
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
            canClick = true;
            useScroll = true;
    }

    private void OnMouseDown() 
    {
        if((cardsUp < 3) && (canClick) && !wasClicked)
        {
            animator.SetTrigger("Turn Up");
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
        canClick = false;
        yield return new WaitForSeconds(delay2);
        if(!correct)
        {
            animator.SetTrigger("Turn Down");
            Wrong.SetActive(true);
            gameManager.GetComponent<CardsCounter>().counter = 0;
            gameManager.GetComponent<CardsCounter>().wrongCombination = 0;
            yield return new WaitForSeconds(delay3);
            animator.ResetTrigger("Turn Down");
            wasClicked = true;
            yield return new WaitForSeconds(delay3);
            canClick = true;
            wasClicked = false;
            yield return new WaitForSeconds(delay4);
            Wrong.SetActive(false);
        }   
    }

    IEnumerator CorrectCombination()
    {
        if(!usedCombinations.Contains(combination))
        {
            usedCombinations.Add(combination);
            canClick = false;
            yield return new WaitForSeconds(delay2);
            Right.SetActive(true);
            gameManager.GetComponent<CardsCounter>().counter = 0;
            gameManager.GetComponent<CardsCounter>().wrongCombination = 0;
            if(combination == gameManager.GetComponent<WishesBehaviour>().wish)
            {
                correct = true;
                gameManager.GetComponent<TimerBehaviour>().time += 6;
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
            usedCombinations.Clear();
        }
    }

}
