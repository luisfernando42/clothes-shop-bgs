using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : Interactable
{
    public ShopUI ShopUI;
    public override void Interact()
    {
        ShopUI.OpenShop();
    }

    public override void StopInteraction()
    {
        ShopUI.CloseShop();
    }
}
