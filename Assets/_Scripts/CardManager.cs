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
        ShuffleDeck();
    }

    public void DrawCard() {
        for (int i = 0; i < cardsToDraw; i++) {
            //int card = Random.Range(0, CardDeck.Count);
            Instantiate(newCard, Vector3.zero, Quaternion.identity, cardCanvas.transform);
        }
    }
    
    void ShuffleDeck() {
        //?We may not need this
        //TODO add all cards to deck
    }

    public void  Discard(EventCard card) {
        //Todo make sure this doesnt error out on us.
        //CardDeck.Remove(card);
        //?We may not need this
    }

}
