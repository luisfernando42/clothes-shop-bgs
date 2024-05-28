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
    private List<ShopItem> inventoryItems = new List<ShopItem>(); 

    private void Awake()
    {
        gameInput = GetComponent<GameInput>();
    }

    private void Start()
    {
        gameInput.OnOpenInventoryAction += GameInput_OnOpenInventoryAction;
    }

    private void GameInput_OnOpenInventoryAction(object sender, EventArgs e)
    {
        OpenOrCloseInventory(isInventoryOpen);
    }

    public void OpenOrCloseInventory(bool isInventoryOpen)
    {
        this.isInventoryOpen = !isInventoryOpen;
        inventory.SetActive(this.isInventoryOpen);
    }

    public List<ShopItem> InventoryList()
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
