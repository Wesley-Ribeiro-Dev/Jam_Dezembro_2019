using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBehaviour : MonoBehaviour
{
    public GameObject Scroll;
    public GameObject mold;
    private bool scrollOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Z)) && !scrollOn)
        {
            if(mold.GetComponent<CardsBehaviour>().useScroll)
            {
                ShowScroll();
            }
        }

        else if(Input.GetKeyDown(KeyCode.Z) && scrollOn)
        {
            HideScroll();
        }
    }

    private void ShowScroll()
    {
        Scroll.SetActive(true);
        scrollOn = true;
    }

    private void HideScroll()
    {
         Scroll.SetActive(false);
         scrollOn = false;
    }

}
