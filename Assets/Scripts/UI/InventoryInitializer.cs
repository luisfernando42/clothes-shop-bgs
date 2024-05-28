using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInitializer : MonoBehaviour
{
    public Image itemIcon;
    public Image playerWearing;
    public void Initialize(Sprite icon, Sprite playerWearing)
    {
        this.itemIcon.sprite = icon;
        this.playerWearing.sprite = playerWearing;
    }
}
