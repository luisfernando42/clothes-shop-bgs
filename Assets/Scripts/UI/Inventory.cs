using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public PlayerInventory inventory;
    private List<ShopItem> inventoryItems;
    public GameObject inventoryListParent;
    public GameObject inventoryItemPrefab;
    private void Start()
    {
        inventoryItems = inventory.InventoryList();
        InitializeItems();
    }

    private void InitializeItems()
    {
        if(inventoryItems.Count > 0) 
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                GameObject inventoryItem = Instantiate(inventoryItemPrefab, inventoryListParent.transform);
                InventoryInitializer inventoryInitializer = inventoryItem.GetComponentInChildren<InventoryInitializer>();
                inventoryInitializer.Initialize(icon: inventoryItems[i].itemIcon, clotheCategory: inventoryItems[i].clotheCategory ,clotheLabel: inventoryItems[i].clotheLabel, shopItem: inventoryItems[i]);
                inventoryInitializer.gameObject.GetComponentInChildren<Button>().onClick.AddListener(() => TryToWearClothes(inventoryInitializer.shopItem));
            }
        }
    }

    private void TryToWearClothes(ShopItem item)
    {
        Debug.Log(item.name);
    }

}
