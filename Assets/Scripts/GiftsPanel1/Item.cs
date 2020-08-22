using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Cake,
        Donut,
        Cookie,
        Coffee
    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Cake: return 50;
            case ItemType.Donut: return 50;
            case ItemType.Cookie: return 50;
            case ItemType.Coffee: return 50;
        }
    }

    public static int GetHappinessValue(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Cake: return 5;
            case ItemType.Donut: return 5;
            case ItemType.Cookie: return 5;
            case ItemType.Coffee: return 5;
        }
    }

    public static int GetExpValue(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Cake: return 2;
            case ItemType.Donut: return 2;
            case ItemType.Cookie: return 2;
            case ItemType.Coffee: return 2;
        }
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Cake: return GiftsPanel1Assets.i.Cake;
            case ItemType.Donut: return GiftsPanel1Assets.i.Cake;
            case ItemType.Cookie: return GiftsPanel1Assets.i.Cake;
            case ItemType.Coffee: return GiftsPanel1Assets.i.Cake;
        }
    }
}
