using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private PlayerInventory inventory;
    private List<ShopItem> inventoryItems;
    public GameObject inventoryListParent;
    public GameObject inventoryItemPrefab;
    private void Start()
    {
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
                inventoryInitializer.Initialize(icon: inventoryItems[i].itemIcon, playerWearing: inventoryItems[i].playerWearing);
                inventoryInitializer.gameObject.GetComponent<Button>().onClick.AddListener(() => TryToWearClothes(inventoryItems[i]));
            }
        }
    }

    private void TryToWearClothes(ShopItem item)
    {

    }

}
