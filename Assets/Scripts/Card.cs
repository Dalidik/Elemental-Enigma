using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Game _game;
    [SerializeField]
    private Sprite _backSprite;
    [SerializeField]
    private Sprite _frontSprite;
    [SerializeField]
    private Sprite _findSprite;

    [SerializeField]
    private Int32 _number;

    public Int32 Number => _number;
    public Boolean Down => this.GetComponent<Image>().sprite == _frontSprite;
    public Boolean Find => this.GetComponent<Image>().sprite == _findSprite;
    
    

    public void TapDown()
    {
        if (!Find)
        {
            if (!_game.FindCard)
            {
                if (!Down)
                {
                    this.GetComponent<Image>().sprite = _frontSprite;
                    _game.OpenCards();
                }
            
            }
            
        }
        
    }

    public void NoFindCard()
    {
        this.GetComponent<Image>().sprite = _backSprite;
    }
    
    public void FindCard()
    {
        this.GetComponent<Image>().sprite = _findSprite;
    }
}
