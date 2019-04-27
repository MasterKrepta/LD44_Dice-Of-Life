using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{

    public const string PlayerTag = "Player";
    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";
    public static GameModes CurrentMode { get; set; }

    public enum GameModes
    {
        SELECTING,
        ROLLING
    }
    
}
