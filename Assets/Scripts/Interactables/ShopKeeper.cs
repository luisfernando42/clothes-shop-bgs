using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : Interactable
{
    public ShopUI ShopUI;

    public override void Interact()
    {
       
    }

    public override void InteractWithCustomer(ICustomer customer)
    {
        ShopUI.OpenShop(customer);
    }

    public override void StopInteraction()
    {
        ShopUI.CloseShop();
    }
}
