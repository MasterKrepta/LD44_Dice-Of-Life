using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Card", menuName ="Cards")]
public class CardData : ScriptableObject
{
    public string Title;
    public string Description;
    public int Action1Amount;
    public Tile.TileTypes ActionType1;
    public int Action2Amount;
    public Tile.TileTypes ActionType2;
}
