using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInitializer : MonoBehaviour
{
    public TMP_Text itemValueTxt;
    public Image itemIcon;
    public ShopItem shopItem;

    public Sprite playerWearing;
    public void Initialize(float itemValue, Sprite itemIcon, Sprite playerWearing, ShopItem shopItem)
    {
        itemValueTxt.text = itemValue.ToString();
        this.itemIcon.sprite = itemIcon;
        this.playerWearing = playerWearing;
        this.shopItem = shopItem;
    }

    public Sprite UpdatePlayerVisual()
    {
        return playerWearing;
    }

}
