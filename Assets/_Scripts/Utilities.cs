using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{

    public const string PlayerTag = "Player";
    public const string GroundTag = "Ground";
    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";
    public static GameModes CurrentMode { get; set; }
    
    public enum GameModes
    {
        ROLLING,
        COLLECTING,
        DRAW_EVENT,
        BUYING,
        SELECTING,

    }
    
    public static void NextAction() {
        switch (CurrentMode) {
            case GameModes.ROLLING:
                
                CurrentMode = GameModes.COLLECTING;
                //PlayerInventory.Instance.UpdateStats();
                break;
            case GameModes.COLLECTING:
                
                CurrentMode = GameModes.DRAW_EVENT;
                CardManager.Instance.DrawCard();
                break;
            case GameModes.DRAW_EVENT:
                CurrentMode = GameModes.BUYING;
                

                break;
            case GameModes.BUYING:
                CurrentMode = GameModes.SELECTING;
                

                break;
            case GameModes.SELECTING:
                
                CurrentMode = GameModes.ROLLING;
                FindObjectOfType<RollDice>().Reset();
                break;
            default:
                break;
        }
        PlayerInventory.Instance.UpdateCurrentMode();
    }
}
