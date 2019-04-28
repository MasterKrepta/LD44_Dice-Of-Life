using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class TileHelper : MonoBehaviour
{
    [SerializeField] GameObject[] Sides;
    [SerializeField] GameObject Tile;
    // Start is called before the first frame update
    void Start() {
        InitTiles();
    }

    private void InitTiles() {
        foreach (var side in Sides) {
            GameObject go = Instantiate(Tile, side.transform.position, side.transform.rotation);
            go.transform.parent = side.transform;
        }
    }
}
  
