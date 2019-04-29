
using System;
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
            int randomTile = UnityEngine.Random.Range(0, Sprites.Count);
            image.sprite = Sprites[randomTile];
            Sprites.Remove(Sprites[randomTile]);
        }
    }

    public void BuyNewTile(Button b) {
        if (CanWeBuy(b)) {
            Destroy(Images[Images.Count - 1]);
            Images.RemoveAt(Images.Count - 1);
            SelectingTile.ParseTileData(b.image.sprite.name.ToString());
            SelectingTile.SelectTileToReplace();
            PlayerInventory.Instance.UpdateStats();
            Utilities.NextAction();
            this.gameObject.SetActive(false);
        }

    }

    private bool CanWeBuy(Button button) {

        string[] split = button.image.sprite.name.Split('_');

        string type = split[0];
        int costToBuy = Convert.ToInt32(split[1]);
        switch (type.ToLower()) {
            case "health":
                
                if (PlayerInventory.Health >= costToBuy) {
                    PlayerInventory.Health -= costToBuy;
                    return true;
                }
                break;
            case "money":
                if (PlayerInventory.Money >= costToBuy) {
                    PlayerInventory.Money -= costToBuy;
                    return true;
                }
                break;
            case "social":
                if (PlayerInventory.Social >= costToBuy) {
                    PlayerInventory.Social -= costToBuy;
                    return true;
                }
                break;
            case "time":
                if (PlayerInventory.Time >= costToBuy) {
                    PlayerInventory.Time -= costToBuy;
                    return true;
                }
                break;
            default:
                return false;
                break;
        }

        return false;

        
    }

    
}
