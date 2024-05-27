using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public List<ShopItem> shopItems;
    public GameObject itemPrefab;
    public GameObject shopItemParent;

    private void InstantiateAllItems()
    {
        for (int i = 0; i < shopItems.Count; i++)
        {
            GameObject shopItem = Instantiate(itemPrefab, shopItemParent.transform.position, Quaternion.identity, shopItemParent.transform);
            shopItem.GetComponent<ItemInitializer>().Initialize(itemIcon: shopItems[i].itemIcon, itemValue: shopItems[i].itemValue, playerWearing: shopItems[i].playerWearing);    
        }
    }

    private void Start()
    {
        InstantiateAllItems();
    }

    public void OpenShop()
    {
        gameObject.SetActive(true);
    }

    public void CloseShop() 
    { 
        gameObject.SetActive(false);
    }
}
