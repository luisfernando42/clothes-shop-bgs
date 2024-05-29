using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerClothing : MonoBehaviour, IWearable
{
    public static PlayerClothing Instance { get; private set; }

    public SpriteResolver dressSpriteResolver = null;
    public SpriteResolver shirtSpriteResolver = null;
    public SpriteResolver pantsSpriteResolver = null;
    public SpriteResolver glassesSpriteResolver = null;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void WearClothes(string category, string label)
    {
        switch (label)
        {
            case ClothesCategory.DRESS_CATEGORY:
                dressSpriteResolver.SetCategoryAndLabel(category, label);
                break;
            case ClothesCategory.SHIRT_CATEGORY:
                dressSpriteResolver.SetCategoryAndLabel(ClothesCategory.DRESS_CATEGORY, "WithoutDress");
                shirtSpriteResolver.SetCategoryAndLabel(category, label);
                break;
            case ClothesCategory.PANTS_CATEGORY:
                dressSpriteResolver.SetCategoryAndLabel(ClothesCategory.DRESS_CATEGORY, "WithoutDress");
                pantsSpriteResolver.SetCategoryAndLabel(category, label);
                break;
            case ClothesCategory.GLASSES_CATEGORY:
                glassesSpriteResolver.SetCategoryAndLabel (category, label);
                break;
        }
    }
}

public static class ClothesCategory
{
    public const string DRESS_CATEGORY = "Dress";
    public const string GLASSES_CATEGORY = "Glasses";
    public const string SHIRT_CATEGORY = "Shirt";
    public const string PANTS_CATEGORY = "Pants";
}