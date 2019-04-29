
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField]List<Image> Images;
    [SerializeField] List<Sprite> Sprites;


    SelectingTile SelectingTile;


    private void Awake() {
        SelectingTile = FindObjectOfType<SelectingTile>();
        PopulateStore();
    }

    public void PopulateStore() {
  
        foreach (Image image in Images) {
            int randomTile = Random.Range(0, Sprites.Count);
            image.sprite = Sprites[randomTile];
            Sprites.Remove(Sprites[randomTile]);
        }
    }

    public void BuyNewTile() {
    
        //TODO select tile to replace
        //remove tile from store. 
        
        Destroy(Images[Images.Count - 1]);
        Images.RemoveAt(Images.Count - 1);
        SelectingTile.ParseTileData(Images[Images.Count - 1].sprite.name.ToString());
        SelectingTile.SelectTileToReplace();
        Utilities.NextAction();
        this.gameObject.SetActive(false);



    }
}
