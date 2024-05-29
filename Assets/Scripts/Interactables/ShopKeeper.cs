using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : Interactable
{
    public ShopUI ShopUI;
    public GameObject shopParent;
    public GameObject shopTemporary;

   

    public override void Interact()
    {
        shopTemporary = Instantiate(ShopUI.gameObject, shopParent.transform);
        ShopUI.OpenShop(shopTemporary);
    }

    public override void StopInteraction()
    {
        ShopUI.CloseShop();
        Destroy(shopTemporary);
    }
}
