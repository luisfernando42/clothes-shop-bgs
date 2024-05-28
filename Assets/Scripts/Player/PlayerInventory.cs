using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, ICustomer
{
    public float walletMoneyAmout = 300;
    private GameInput gameInput;
    public GameObject inventory;
    private bool isInventoryOpen = false;
    private List<ShopItem> inventoryItems; 

    private void Awake()
    {
        gameInput = GetComponent<GameInput>();
    }

    private void GameInput_OnOpenInventoryAction(object sender, EventArgs e)
    {
        OpenOrCloseInventory(isInventoryOpen);
    }

    public void OpenOrCloseInventory(bool isInventoryOpen)
    {
        inventory.SetActive(!isInventoryOpen);
    }

    public List<ShopItem> inventoryList()
    {
        return inventoryItems;
    }

    public void BuyItem(ShopItem item)
    {
        if (!inventoryItems.Contains(item))
        {
            walletMoneyAmout -= item.itemValue;
            inventoryItems.Add(item);
        }
    }

    public void SellItem(ShopItem item)
    {
        if (inventoryItems.Contains(item))
        {
            walletMoneyAmout += item.itemValue;
            inventoryItems.Remove(item);
        }
    }
}
