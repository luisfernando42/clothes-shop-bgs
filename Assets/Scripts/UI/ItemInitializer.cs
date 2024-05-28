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

    public string clotheLabel;
    public string clotheCategory;
    public void Initialize(float itemValue, Sprite itemIcon, string clotheLabel, string clotheCategory, ShopItem shopItem)
    {
        itemValueTxt.text = itemValue.ToString();
        this.itemIcon.sprite = itemIcon;
        this.clotheLabel = clotheLabel;
        this.clotheCategory = clotheCategory;
        this.shopItem = shopItem;
    }
}
