using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, ICustomer
{
    public float walletMoneyAmout;
    public void BuyItem(ShopItem item)
    {
        Debug.Log(item);
    }

    public void SellItem(ShopItem item)
    {
        Debug.Log(item);
    }
}
