using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingTile : MonoBehaviour
{
    [SerializeField] GameObject StoreObject;
    [SerializeField] Animator cameraAnimator;
    public Tile newTileToSwap;

    private void Start() {
        StoreObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Utilities.CurrentMode == Utilities.GameModes.BUYING) {
            ShowStore();
        
        }

        if (Utilities.CurrentMode == Utilities.GameModes.ROLLING) {
            cameraAnimator.Play("cameraIdle");

        }
        


        //TODO if we need this its not running every frame
        if (Utilities.CurrentMode == Utilities.GameModes.SELECTING) {
            cameraAnimator.SetTrigger("Zoom");
            SelectTileToReplace();

        }
        else {
            cameraAnimator.StopPlayback();
            //cameraAnimator.Play("cameraIdle");
        }
    }

    public void SelectTileToReplace() {
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            //Debug.Log(hit.transform.name);
            Tile hitTile = hit.transform.gameObject.GetComponent<Tile>();
            
            if (Input.GetMouseButtonDown(0) && hitTile != null) {
                SwapTile(newTileToSwap, hitTile);
                
            }
        }

    }

    private void SwapTile(Tile newTileToSwap, Tile hitTile) {
        Debug.Log("Tiles swapped");
        hitTile.Type = newTileToSwap.Type;
        hitTile.TileValue = newTileToSwap.TileValue;
        hitTile.Type = newTileToSwap.Type;
        hitTile.setTileColors();

        StoreObject.SetActive(false);
        cameraAnimator.SetTrigger("Reset");
        Utilities.NextAction();

    }

    private void ShowStore() {
        StoreObject.SetActive(true);
    }

    public Tile ParseTileData(string spriteName) {
        //Default type
        Tile.TileTypes newType = Tile.TileTypes.HEALTH;

        string[] split = spriteName.Split('_');
        

        string type = split[0];
        int tileValue = Convert.ToInt32(split[1]);
        switch (type.ToLower()) {
            case "health":
                newType = Tile.TileTypes.HEALTH;
                break;
            case "money":
                newType = Tile.TileTypes.MONEY;
                break;
            case "social":
                newType = Tile.TileTypes.SOCIAL;
                break;
            case "time":
                newType = Tile.TileTypes.TIME;
                break;
            default:
                break;
        }
        Tile newTile = new Tile(newType, tileValue);
        newTileToSwap = newTile;
        return newTile;
    }

}
