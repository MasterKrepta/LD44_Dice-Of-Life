using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] float hoverAmount = .2f;
    [SerializeField] Material[] Materials;
    MeshRenderer mr;
    public enum TileTypes
    {
        SOCIAL,
        HEALTH,
        MONEY,
        TIME
    }
    

    public TileTypes Type { get; set; }
    public int Amount { get; set; }
    Vector3 origPos;
    Vector3 origRot;

    private void Start() {
        mr = GetComponent<MeshRenderer>();
        origPos = transform.position;
        origRot = transform.eulerAngles;
    }

    public int Receive() {
        return Amount;
    }

    
    private void OnMouseEnter() {
        mr.material = Materials[1];
        //transform.up += new Vector3(0, hoverAmount, 0);
        //transform.rotation = Quaternion.Euler(origRot);
    }

    private void OnMouseExit() {
        mr.material = Materials[0];
        //transform.up = origPos;
    }
}
