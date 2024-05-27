using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "ScriptableObjects/ShopItem")]
public class ShopItem : ScriptableObject
{
    public float itemValue;
    public Sprite itemIcon;
    public Sprite playerWearing;
}
