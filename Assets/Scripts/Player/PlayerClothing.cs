using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerClothing : MonoBehaviour, IWearable
{
    public static PlayerClothing Instance { get; private set; }

    public SpriteResolver dressSpriteResolver = null;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        dressSpriteResolver = GetComponentInChildren<SpriteResolver>();
    }

    public void WearDress(string category, string label)
    {
        dressSpriteResolver.SetCategoryAndLabel(category, label);
    }
}

public enum ClothesCategory
{
    Dress, Glass, Shirt, Skirt
}

public static class ClothesLabel
{
    static string BLUE_DRESS_LABEL = "Blue Dress";
    static string RED_DRESS_LABEL = "Red Dress";
}