using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerInventory : MonoBehaviour
{
    public static float Time; // Decreases each turn/ can be increased by buying luxurays... like house maid
    public static float Money; // needed to pay for just about everything: Basic resource
    public static float Social; // friends  cost money but increase happiness
    public static float Health; // needs to be maintained to maximize time left alive. cards can make you sick

    public static PlayerInventory Instance = null;

    [SerializeField] TMP_Text txtTime;
    [SerializeField]  TMP_Text txtMoney;
    [SerializeField]  TMP_Text txtSocial;
    [SerializeField]  TMP_Text txtHealth;
    [SerializeField] TMP_Text currentMode;
    
    private void Start() {
        if (Instance == null) {
            Instance = this;
        }
        InitResources();
        UpdateStats();
    }

    private void InitResources() {
        Time = 20; // average life
        Money = 10;
        Social = 5;
        Health = 25;

    }

    public  void CollectResource(Tile.TileTypes type, int amount) {
        switch (type) {
            case Tile.TileTypes.SOCIAL:
                Social += amount;
                txtSocial.GetComponent<Animator>().SetTrigger("ResourceGet");
                break;
            case Tile.TileTypes.HEALTH:
                Health += amount;
                txtHealth.GetComponent<Animator>().SetTrigger("ResourceGet");
                break;
            case Tile.TileTypes.MONEY:
                Money += amount;
                txtMoney.GetComponent<Animator>().SetTrigger("ResourceGet");
                break;
            case Tile.TileTypes.TIME:
                Time += amount;
                txtTime.GetComponent<Animator>().SetTrigger("ResourceGet");
                break;  
            default:
                break;
        }

        UpdateStats();
    }

    public   void UpdateStats() {
        txtTime.text = $"Time: {Time} Years";
        txtMoney.text = $"Money: ${Money}";
        txtSocial.text = $"Social: {Social}%";
        txtHealth.text = $"Health: {Health}%";

        UpdateCurrentMode();
        
    }

    public void UpdateCurrentMode() {
        currentMode.text = $"Current Mode: {Utilities.CurrentMode.ToString()}";
    }
}
