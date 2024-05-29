using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, ICustomer
{
    public float walletMoneyAmout = 2000;
    private GameInput gameInput;
    public GameObject inventoryParent;
    public GameObject inventoryPrefab;
    public GameObject inventoryTemporary;
    private bool isInventoryOpen = false;
    private List<ShopItem> inventoryItems = new List<ShopItem>();

    public static PlayerInventory Instance { get; private set; }
    public static ICustomer CustomerInstance { get; private set; }

    private void Awake()
    {
        gameInput = GetComponent<GameInput>();
        if (Instance == null)
        {
            Instance = this;
        }
        if (CustomerInstance == null) 
        { 
            CustomerInstance = this;
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
        this.isInventoryOpen = !isInventoryOpen;
        if (isInventoryOpen) 
        {
            inventoryParent.SetActive(false);
            if(inventoryTemporary != null) Destroy(inventoryTemporary);
        }
        else
        {
            inventoryParent.SetActive(true);
            inventoryTemporary = Instantiate(inventoryPrefab, inventoryParent.transform);
        }
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
