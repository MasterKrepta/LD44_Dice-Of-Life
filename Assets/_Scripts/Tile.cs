using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] float hoverAmount = .2f;
    [SerializeField] Material[] Materials;
    MeshRenderer mr;
    [SerializeField] LayerMask groundLayer;
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

    public TileTypes Type;
    public TileColor tileColor;

    [SerializeField]
    public int TileValue = 1;

    Vector3 origPos;
    Vector3 origRot;

    private void Start() {
        setTileColors();
        mr = GetComponent<MeshRenderer>();
        origPos = transform.position;
        origRot = transform.eulerAngles;
    }

    private void setTileColors() {
        switch (Type) {
            case TileTypes.SOCIAL:
                tileColor = TileColor.BLUE;
                break;
            case TileTypes.HEALTH:
                tileColor = TileColor.RED;
                break;
            case TileTypes.MONEY:
                tileColor = TileColor.GREEN;
                break;
            case TileTypes.TIME:
                tileColor = TileColor.GOLD;
                break;
            default:
                break;
        }

    }

    public int Receive() {
        return TileValue;
    }

    
    private void OnMouseEnter() {
        if (Utilities.CurrentMode == Utilities.GameModes.SELECTING) {
            mr.material = Materials[1];
            Debug.Log(this.name);
            //transform.up += new Vector3(0, hoverAmount, 0);
            //transform.rotation = Quaternion.Euler(origRot);
        }

    }

    private void OnMouseExit() {
        if (Utilities.CurrentMode == Utilities.GameModes.SELECTING) {
            mr.material = Materials[0];
            //transform.up = origPos;
        }
    }

    //?This may not be nessicary
    //private void OnTriggerStay(Collider other) {
    //    if (other.tag == Utilities.GroundTag) {
    //        onGround = true;
    //    }
     
    //}

    //private void OnTriggerExit(Collider other) {
    //    if (other.tag == Utilities.GroundTag) {
    //        onGround = false;
    //    }
    //}

    public bool IsGrounded() {
  
        if (Physics.Raycast(transform.position, -transform.up, Mathf.Infinity, groundLayer)) {
           
            return true;
        }
        else {
            return false;
        }
            
        //return onGround;
    }

    
}
