using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInitializer : MonoBehaviour
{
    public Image itemIcon;
    public ShopItem shopItem;
    public string clotheCategory;
    public string clotheLabel;
    public void Initialize(Sprite icon, string clotheCategory,string clotheLabel, ShopItem shopItem)
    {
        this.itemIcon.sprite = icon;
        this.clotheCategory = clotheCategory;
        this.clotheLabel = clotheLabel;
        this.shopItem = shopItem;
    }
}
