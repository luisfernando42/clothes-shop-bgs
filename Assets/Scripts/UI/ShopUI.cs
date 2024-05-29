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

    private ShopItem selectedItem;
    private GameObject selectedGO;

    private GameObject instantiatedPrefab;


    private void Start()
    {
        InstantiateAllBuyItems();
        InstantiateAllSellItems();
    }

    private void InstantiateAllBuyItems()
    {
        if (shopBuyItems.Count > 0)
        {
            for (int i = 0; i < shopBuyItems.Count; i++)
            {
                GameObject shopItem = Instantiate(itemPrefab, shopItemBuyParent.transform);
                ItemInitializer itemInitializer = shopItem.GetComponent<ItemInitializer>();
                itemInitializer.Initialize(itemIcon: shopBuyItems[i].itemIcon, itemValue: shopBuyItems[i].itemValue, clotheCategory: shopBuyItems[i].clotheCategory, clotheLabel: shopBuyItems[i].clotheLabel, shopItem: shopBuyItems[i]);
                shopItem.GetComponent<Button>().onClick.AddListener(() => SelectItem(itemObject: shopItem, shopItem: itemInitializer.shopItem));
            }
        }
    }

    private void InstantiateAllSellItems()
    {
        shopSellItems = PlayerInventory.Instance.InventoryList();
        if (shopSellItems.Count > 0)
        {
            for (int i = 0; i < shopSellItems.Count; i++)
            {
                GameObject shopItem = Instantiate(itemPrefab, shopItemSellParent.transform.position, Quaternion.identity, shopItemSellParent.transform);
                ItemInitializer itemInitializer = shopItem.GetComponent<ItemInitializer>();
                itemInitializer.Initialize(itemIcon: shopSellItems[i].itemIcon, itemValue: shopSellItems[i].itemValue, clotheCategory: "", clotheLabel: "", shopItem: shopSellItems[i]);
                shopItem.GetComponent<Button>().onClick.AddListener(() => SelectItem(itemObject: shopItem, shopItem: itemInitializer.shopItem));
            }
        }
    }

    private void SelectItem(ShopItem shopItem, GameObject itemObject)
    {
        selectedItem = null;
        selectedGO = null;
        selectedGO = itemObject;
        Button itemButton = itemObject.GetComponent<Button>();    
        itemButton.Select();
        selectedItem = shopItem;
    }

    public void OpenShop(GameObject instantiatedPrefab)
    {
        this.instantiatedPrefab = instantiatedPrefab;
        gameObject.SetActive(true);
        InstantiateAllSellItems();
    }

    public void CloseShop() 
    {
        Destroy(instantiatedPrefab);
    }

    public void TryToBuyItem()
    {
        if (selectedItem != null) 
        {
            shopSellItems.Add(selectedItem);
            PlayerInventory.CustomerInstance.BuyItem(selectedItem);
        }
    }
    public void TryToSellItem()
    {
        if (selectedItem != null)
        {
            shopSellItems.Remove(selectedItem);
            PlayerInventory.CustomerInstance.SellItem(selectedItem);
            Destroy(selectedGO);
        }
    }
}
