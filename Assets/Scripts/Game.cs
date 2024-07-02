using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Transform _panelCard;
    [SerializeField]
    private List<Card> _cards;
    [SerializeField]
    private Int32 _numberCard;
    [SerializeField]
    private Boolean _findCard;

    [SerializeField]
    private GameObject WinScreen;
    public Boolean FindCard => _findCard;

    public static Int32 ScoreCount;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    private void Awake()
    {
        for (Int32 i = 0; i < _panelCard.childCount; i++)
        {
            _panelCard.GetChild(i).transform.SetSiblingIndex(Random.Range(0, _panelCard.childCount));
        }
    }

    private void Start()
    {
        ScoreCount = 0;
        for (Int32 i = 0; i < _panelCard.childCount; i++)
        {
            _cards.Add(_panelCard.GetChild(i).GetComponent<Card>());
        }
    }

    private void Update()
    {
        _scoreText.text = "" + Mathf.Round(ScoreCount);
    }

    public void OpenCards()
    {
        var openCard = 0;

        foreach (Card card in _cards)
        {
            if (card.Down)
            {
                if (openCard == 0)
                {
                    _numberCard = card.Number;
                }
                openCard++;
            }
        }

        if (openCard == 2)
        {
            CheckCard();
        }
    }

     public void CheckCard()
     {
         var a = 0;
        foreach (Card card in _cards)
        {
            if (card.Down && card.Number == _numberCard)
            {
                a++;
            }
        }

        if (a == 2)
        {
            FindCards();
        }
        else
        {
            NoFindCards();
        }
    }

     public void FindCards()
     {
         foreach (Card card in _cards)
         {
             if (card.Down)
             {
                 ScoreCount += 30;
                 StartCoroutine(Win(card));
             }
         }
     }

     public void NoFindCards()
     {
         foreach (Card card in _cards)
         {
             if (card.Down)
             {
                 StartCoroutine(NoFind(card));
             }
         }
     }

     IEnumerator NoFind(Card card)
     {
         _findCard = true;
         yield return new WaitForSeconds(1f);
         card.GetComponent<Card>().NoFindCard();
         _findCard = false;
     }
     
     
     IEnumerator Win(Card card)
     {
         _findCard = true;
         yield return new WaitForSeconds(1f);
         card.GetComponent<Card>().FindCard();
       
         _findCard = false;
         Win();
     }

     public void Win()
     {
         var a = 0;
         foreach (Card card in _cards)
         {
             if (card.Find)
             {
                 a++;
             }

             if (a == _panelCard.childCount)
             {
                 WinScreen.SetActive(true);
             }
         }
         
     }
}
