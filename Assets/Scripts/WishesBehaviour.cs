using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WishesBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentWish;
    public GameObject mold;
    public int wish;
    public List<int> usedNumbers = new List<int> ();

    // Start is called before the first frame update
    void Start()
    {
        ChangeWish();
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetKeyDown(KeyCode.A))
            {
                ChangeWish();
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
    }
}
