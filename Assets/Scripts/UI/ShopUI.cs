using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject itemPrefab;
    
    public List<ShopItem> shopBuyItems;
    public GameObject shopItemBuyParent;

    public List<ShopItem> shopSellItems;
    public GameObject shopItemSellParent;

    private ICustomer customer;

    private ShopItem selectedItem; 

    private void InstantiateAllBuyItems()
    {
        for (int i = 0; i < shopBuyItems.Count; i++)
        {
            GameObject shopItem = Instantiate(itemPrefab, shopItemBuyParent.transform);
            ItemInitializer itemInitializer = shopItem.GetComponent<ItemInitializer>();
            itemInitializer.Initialize(itemIcon: shopBuyItems[i].itemIcon, itemValue: shopBuyItems[i].itemValue, playerWearing: shopBuyItems[i].playerWearing, shopItem: shopBuyItems[i]);    
            shopItem.GetComponent<Button>().onClick.AddListener(() => SelectItem(itemObject: shopItem, shopItem: itemInitializer.shopItem));
        }
    }

    private void InstantiateAllSellItems()
    {
        for (int i = 0; i < shopSellItems.Count; i++)
        {
            GameObject shopItem = Instantiate(itemPrefab, shopItemSellParent.transform.position, Quaternion.identity, shopItemSellParent.transform);
            ItemInitializer itemInitializer = shopItem.GetComponent<ItemInitializer>();
            itemInitializer.Initialize(itemIcon: shopSellItems[i].itemIcon, itemValue: shopSellItems[i].itemValue, playerWearing: shopSellItems[i].playerWearing, shopItem: shopSellItems[i]);
            shopItem.GetComponent<Button>().onClick.AddListener(() => SelectItem(itemObject: shopItem, shopItem: itemInitializer.shopItem));
        }
    }

    private void Start()
    {
        InstantiateAllBuyItems();
        InstantiateAllSellItems();
    }

    private void SelectItem(ShopItem shopItem, GameObject itemObject)
    {
        
        Button itemButton = itemObject.GetComponent<Button>();    
        itemButton.Select();
        selectedItem = shopItem;
    }

    public void OpenShop(ICustomer customer)
    {
        this.customer = customer;
        gameObject.SetActive(true);
    }

    public void CloseShop() 
    {
        customer = null;
        gameObject.SetActive(false);
    }

    public void TryToBuyItem()
    {
        if (selectedItem != null) 
        {
            customer.BuyItem(selectedItem);
        }
    }
    public void TryToSellItem()
    {
        if (selectedItem != null)
        {
            customer.SellItem(selectedItem);
        }
    }
}
