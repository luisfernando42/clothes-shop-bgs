using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();
    public abstract void InteractWithCustomer(ICustomer customer);
    public abstract void StopInteraction();


}
