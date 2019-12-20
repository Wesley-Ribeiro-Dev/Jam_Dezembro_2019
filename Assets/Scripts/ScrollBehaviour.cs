using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject Scroll;
    [SerializeField] private GameObject mold;
    [SerializeField] private GameObject mold2;
    [SerializeField] private GameObject gameManager;
    private bool scrollOn = false;
    public bool scrollOff = true;

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.A)) && !scrollOn)
        {
            if(mold.GetComponent<CardsBehaviour>().useScroll)
            {
                ShowScroll();
                scrollOff = false;
            }
        }

        else if(Input.GetKeyDown(KeyCode.A) && scrollOn)
        {
            HideScroll();
            scrollOff = true;
        }
    }

    private void ShowScroll()
    {
        Scroll.SetActive(true);
        scrollOn = true;
        gameManager.GetComponent<TimerBehaviour>().time -= 5;
    }

    private void HideScroll()
    {
         Scroll.SetActive(false);
         scrollOn = false;
    }

}
