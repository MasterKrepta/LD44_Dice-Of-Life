using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    MeshRenderer mr;
    [SerializeField]
    public int TileValue = 1;

    [SerializeField] Material highlight;
    [SerializeField] Material[] HealthMats;
    [SerializeField] Material[] MoneyMats;
    [SerializeField] Material[] SocialMats;
    [SerializeField] Material[] TimeMats;
    
    public LayerMask groundLayer;
    public enum TileTypes
    {
        SOCIAL,
        HEALTH,
        MONEY,
        TIME
    }
    public enum TileColor
    {
        BLUE,
        GREEN,
        RED,
        GOLD
    }
    [SerializeField]bool onGround;

    Color originalColor;

    public TileTypes Type;
    public TileColor tileColor;

    private void Start() {
        mr = GetComponent<MeshRenderer>();
        setTileColors();
        originalColor = mr.material.color;
    }

    public void setTileColors() {
        if (mr == null) {
            mr = GetComponent<MeshRenderer>();
        }
            switch (Type) {
                case TileTypes.SOCIAL:
                    //tileColor = TileColor.BLUE;
                    mr.material = SocialMats[TileValue - 1];
                    break;
                case TileTypes.HEALTH:
                    //tileColor = TileColor.RED;
                    mr.material = HealthMats[TileValue -1];
                    break;
                case TileTypes.MONEY:
                    //tileColor = TileColor.GREEN;
                    mr.material = MoneyMats[TileValue - 1];
                    break;
                case TileTypes.TIME:
                    //tileColor = TileColor.GOLD;
                    mr.material = TimeMats[TileValue - 1];

                    break;
                default:
                    break;
            }

    }

     void OnMouseEnter() {
        
        if (Utilities.CurrentMode == Utilities.GameModes.SELECTING) {
            mr.material.color = highlight.color;

        }
    }
     void OnMouseExit() {
        
        if (Utilities.CurrentMode == Utilities.GameModes.SELECTING) {
            mr.material.color = originalColor;
            
            //transform.up = origPos;
        }
    }

    public Tile(TileTypes type, int tileValue) {
        Debug.Log("CONSTRUCTOR CALLED");
        Type = type;
        TileValue = tileValue;
        //setTileColors();
       // mr = GetComponent<MeshRenderer>();
    }
    


    public bool IsGrounded() {
        if (Physics.Raycast(transform.position, -transform.up, Mathf.Infinity, groundLayer)) {
           
            return true;
        }
        else {
            return false;
        }
    }
}