using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInitializer : MonoBehaviour
{
    public TMP_Text itemValueTxt;
    public Image itemIcon;

    public Sprite playerWearing;
    public void Initialize(float itemValue, Sprite itemIcon, Sprite playerWearing)
    {
        itemValueTxt.text = itemValue.ToString();
        this.itemIcon.sprite = itemIcon;
        this.playerWearing = playerWearing;
    }

    public Sprite UpdatePlayerVisual()
    {
        return playerWearing;
    }

}
