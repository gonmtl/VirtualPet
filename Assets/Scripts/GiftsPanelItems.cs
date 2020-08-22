using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GiftsPanelItems : MonoBehaviour
{
    public Transform giftsContainer;
    public Transform giftsTemplate;

    private void Awake()
    {
        giftsContainer = transform.Find("container");
        giftsTemplate = giftsContainer.Find("GiftsTemplate");
        giftsTemplate.gameObject.SetActive(true);
    }


    private void Start()
    {

        Debug.Log("Entro a start");

        CreateItemButton
            (
            Item.GetSprite(Item.ItemType.Cake),
            "Cake", Item.GetCost(Item.ItemType.Cake),
            Item.GetHappinessValue(Item.ItemType.Cake),
            Item.GetExpValue(Item.ItemType.Cake),
            0
            );

       CreateItemButton
            (
            Item.GetSprite(Item.ItemType.Donut),
            "Donut", Item.GetCost(Item.ItemType.Donut),
            Item.GetHappinessValue(Item.ItemType.Donut),
            Item.GetExpValue(Item.ItemType.Donut),
            1
            );

        CreateItemButton
            (
            Item.GetSprite(Item.ItemType.Cookie),
            "Cookie", Item.GetCost(Item.ItemType.Cookie),
            Item.GetHappinessValue(Item.ItemType.Cookie),
            Item.GetExpValue(Item.ItemType.Cookie),
            2
            );

        CreateItemButton
            (
            Item.GetSprite(Item.ItemType.Coffee),
            "Coffee", Item.GetCost(Item.ItemType.Coffee),
            Item.GetHappinessValue(Item.ItemType.Coffee),
            Item.GetExpValue(Item.ItemType.Coffee),
            3
            );

    }

    private void CreateItemButton(Sprite itemSprite, string itemName, int itemCost, int happinessValue, int expValue, int positionIndex)
    {

        Debug.Log("Entro a create");

        Transform giftsTemplateTransform = Instantiate(giftsTemplate, giftsContainer);
        RectTransform giftsTemplateRectTransform = giftsTemplate.GetComponent<RectTransform>();

        float giftTemplateHeight = 200f;
        giftsTemplateRectTransform.anchoredPosition = new Vector2(0, -giftTemplateHeight * positionIndex);

        giftsTemplateTransform.Find("Name").GetComponent<TextMeshProUGUI>().SetText(itemName);
        giftsTemplateTransform.Find("Price").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        giftsTemplateTransform.Find("HappinessValue").GetComponent<TextMeshProUGUI>().SetText(happinessValue.ToString());
        giftsTemplateTransform.Find("EXPValue").GetComponent<TextMeshProUGUI>().SetText(expValue.ToString());

        giftsTemplateTransform.Find("Icon").GetComponent<Image>().sprite = itemSprite;
        
    } 

    


}

