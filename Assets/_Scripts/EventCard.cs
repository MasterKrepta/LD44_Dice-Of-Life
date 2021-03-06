﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EventCard : MonoBehaviour
{
    [SerializeField] CardData data;
    [SerializeField] TMP_Text txtTitle;
    [SerializeField] TMP_Text txtDesc;
    [SerializeField] TMP_Text txtAction1;
    [SerializeField] TMP_Text txtAction2;

    private void Start() {
        InitCard();
        txtTitle.text = data.Title;
        this.gameObject.name = txtTitle.text;
        txtDesc.text = data.Description;
        txtAction1.text = $"+{data.Action1Amount} to {data.ActionType1}";
        txtAction2.text = $"{data.Action2Amount} to {data.ActionType2}";
        ValidateCard(data.ActionType2, data.Action2Amount);
    }

    private void ValidateCard(Tile.TileTypes type, int amount) {
        switch (type) {
            case Tile.TileTypes.SOCIAL:
                if (PlayerInventory.Social < amount) {
                    this.enabled = false;
                }
                break;
            case Tile.TileTypes.HEALTH:
                if (PlayerInventory.Health < amount) {
                    this.enabled = false;
                }
                break;
            case Tile.TileTypes.MONEY:
                if (PlayerInventory.Money < amount) {
                    this.enabled = false;
                }
                break;
            case Tile.TileTypes.TIME:
                if (PlayerInventory.Time < amount) {
                    this.enabled = false;
                }
                break;
            default:
                break;
        }
    }

    private void InitCard() {
        int index = UnityEngine.Random.Range(0, CardManager.Instance.CardDeck.Count);
        data = CardManager.Instance.CardDeck[index];
        CardManager.Instance.CardDeck.RemoveAt(index);
    }

    public void UseCard() {
        if (CanWeUseCard()) {
            SoundManager.Instance.Play(SoundManager.Instance.tickSound);
            PlayerInventory.Instance.CollectResource(data.ActionType1, data.Action1Amount);
            PlayerInventory.Instance.CollectResource(data.ActionType2, data.Action2Amount);

            foreach (EventCard card in GameObject.FindObjectsOfType<EventCard>()) {
                Destroy(card.gameObject);
            }
            Utilities.NextAction();
        }
    }

    private bool CanWeUseCard() {
        //IT has to be > then since the amount2 is always a negative number
        switch (data.ActionType2) {
            case Tile.TileTypes.SOCIAL:
                if ((PlayerInventory.Social + data.Action2Amount) < 0) {
                    return false;
                }
                break;
            case Tile.TileTypes.HEALTH:
                if ((PlayerInventory.Health + data.Action2Amount) < 0) {
                    return false;
                }
                break;
            case Tile.TileTypes.MONEY:
                if ((PlayerInventory.Money + data.Action2Amount) < 0) {
                    return false;
                }
                break;
            case Tile.TileTypes.TIME:
                if ((PlayerInventory.Time + data.Action2Amount) < 0) {
                    return false;
                }
                break;
            default:
                return true;
                break;
        }
        return true;
    }
}