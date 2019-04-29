using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<CardData> CardDeck;
    Image image;
    [SerializeField] GameObject cardCanvas;
    [SerializeField] EventCard newCard;
    
    [SerializeField] int cardsToDraw = 2;
    [SerializeField] Transform[] spawnPoints;

    public static CardManager Instance = null;

    // Start is called before the first frame update
    void Start()
    {
        
        if (Instance == null) {
            Instance = this;
        }
    }

    public void DrawCard() {
        if (CardDeck.Count < cardsToDraw) {
            cardsToDraw = CardDeck.Count;
            
        }
        if (CardDeck.Count <= 0) {
            //TODO what happens when we run out of cards
            cardsToDraw = 0;
            Utilities.NextAction();
        }

        for (int i = 0; i < cardsToDraw; i++) {
            //int card = Random.Range(0, CardDeck.Count);
            Instantiate(newCard, Vector3.zero, Quaternion.identity, cardCanvas.transform);
        }
    }

}
