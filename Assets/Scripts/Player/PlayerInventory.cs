using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, ICustomer
{
    public float walletMoneyAmout = 2000;
    private GameInput gameInput;
    public GameObject inventory;
    private bool isInventoryOpen = false;
    private List<ShopItem> inventoryItems = new List<ShopItem>();

    public ShopUI shopUI;

    public static PlayerInventory Instance { get; private set; }

    private void Awake()
    {
        gameInput = GetComponent<GameInput>();
        if (Instance == null)
        {
            Instance = this;
        }
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
        shopUI.CloseShop();
        this.isInventoryOpen = !isInventoryOpen;
    }

    public List<ShopItem> InventoryList()
    {
        return inventoryItems;
    }

    public void BuyItem(ShopItem item)
    {
        if (!inventoryItems.Contains(item) && inventoryItems.Count <=2)
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
