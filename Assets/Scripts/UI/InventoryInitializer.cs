using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInitializer : MonoBehaviour
{
    public Image itemIcon;
    public Sprite playerWearing;
    public ShopItem shopItem;
    public void Initialize(Sprite icon, Sprite playerWearing, ShopItem shopItem)
    {
        this.itemIcon.sprite = icon;
        this.playerWearing = playerWearing;
        this.shopItem = shopItem;
    }
}
