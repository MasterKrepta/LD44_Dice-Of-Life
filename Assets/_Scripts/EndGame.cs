using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EndGame : MonoBehaviour
{
    [SerializeField] TMP_Text Final;
    string EndingString;
    
    enum WinCondion
    {
        START,
        HEALTH, 
        MONEY,
        SOCIAL,
        TIME
    }
    WinCondion win;

    string introString = "Greetings my child. I can see from your actions through the course of your life, what it is that you valued.";
    string YouValuedMoney = $"\n\nLooking back, you sacrificed time with family and friends to accumulate wealth. You ended up with {PlayerInventory.Money} Dollars. Was it worth it?";
    string YouValuedTime = $"\n\nLooking back, I can see you did all you could to live as long as possible, enjoying the simple act of being.";
    string YouValuedSocial = $"\n\nLooking back, I can see Friends and Family is very important to you. If I had to give you a rating it would be {PlayerInventory.Social} out of 100";
    string YouValuedHealth = $"\n\nLooking back, I can see you took care of your body. doing all you could to keep in peak physical shape. {PlayerInventory.Health}";
    string LastStats = $"\n\n\n\nFinalStats\n\nTime: {PlayerInventory.Time} --- Money: {PlayerInventory.Money} --- Social: {PlayerInventory.Social} --- Health: {PlayerInventory.Health}";

    // Start is called before the first frame update
    void Start()
    {
        win = WinCondion.START;
        CheckForEnding();
        switch (win) {
            case WinCondion.START:
                EndingString = YouValuedTime;
                break;
            case WinCondion.HEALTH:
                EndingString = YouValuedHealth;
                break;
            case WinCondion.MONEY:
                EndingString = YouValuedMoney;
                break;
            case WinCondion.SOCIAL:
                EndingString = YouValuedSocial;
                break;
            case WinCondion.TIME:
                EndingString = YouValuedTime;
                break;
            default:
                break;
        }
        Final.text = introString + EndingString + LastStats;
    }

    private void CheckForEnding() {
        float greatest = 0;
        if (PlayerInventory.Money > greatest) {
            greatest = PlayerInventory.Money;
            win = WinCondion.MONEY;
        }
        else if (PlayerInventory.Health > greatest) {
            greatest = PlayerInventory.Health;
            win = WinCondion.HEALTH;
        }
        else if (PlayerInventory.Social > greatest) {
            greatest = PlayerInventory.Social;
            win = WinCondion.SOCIAL;
        }
        else if (PlayerInventory.Time > greatest) {
            greatest = PlayerInventory.Time;
            win = WinCondion.TIME;
        }
    }


}
