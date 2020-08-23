using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GiftsPanelItems : MonoBehaviour
{
    public Transform giftsContainer;
    public Transform giftsTemplate;
    public Transform buttonSelect;


    private void Awake()
    {
        giftsContainer = transform.Find("container");
        giftsTemplate = giftsContainer.Find("GiftsTemplate");
        giftsTemplate.gameObject.SetActive(false);
    }


    private void Start()
    {

        Debug.Log("Entro a start");

        CreateItemButton
            (
            Item.ItemType.Cake,
            Item.GetSprite(Item.ItemType.Cake),
            "Cake", Item.GetCost(Item.ItemType.Cake),
            Item.GetHappinessValue(Item.ItemType.Cake),
            Item.GetExpValue(Item.ItemType.Cake),
            1
            );

       CreateItemButton
            (
            Item.ItemType.Donut,
            Item.GetSprite(Item.ItemType.Donut),
            "Donut", Item.GetCost(Item.ItemType.Donut),
            Item.GetHappinessValue(Item.ItemType.Donut),
            Item.GetExpValue(Item.ItemType.Donut),
            2
            );

        CreateItemButton
            (
            Item.ItemType.Cookie,
            Item.GetSprite(Item.ItemType.Cookie),
            "Cookie", Item.GetCost(Item.ItemType.Cookie),
            Item.GetHappinessValue(Item.ItemType.Cookie),
            Item.GetExpValue(Item.ItemType.Cookie),
            3
            );

        CreateItemButton
            (
            Item.ItemType.Coffee,
            Item.GetSprite(Item.ItemType.Coffee),
            "Coffee", Item.GetCost(Item.ItemType.Coffee),
            Item.GetHappinessValue(Item.ItemType.Coffee),
            Item.GetExpValue(Item.ItemType.Coffee),
            4
            );

    }

    private void CreateItemButton(Item.ItemType itemType ,Sprite itemSprite, string itemName, int itemCost, int happinessValue, int expValue, int positionIndex)
    {

        Debug.Log("Entro a create");

        Transform giftsTemplateTransform = Instantiate(giftsTemplate, giftsContainer);
        RectTransform giftsTemplateRectTransform = giftsTemplate.GetComponent<RectTransform>();
        Transform buttonSelect = giftsTemplateTransform.Find("Select");

        float giftTemplateHeight = 200f;
        giftsTemplateRectTransform.anchoredPosition = new Vector2(0, -giftTemplateHeight * positionIndex);
        giftsTemplateTransform.gameObject.SetActive(true);

        giftsTemplateTransform.Find("Name").GetComponent<TextMeshProUGUI>().SetText(itemName);
        buttonSelect.Find("Price").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        giftsTemplateTransform.Find("HappinessValue").GetComponent<TextMeshProUGUI>().SetText(happinessValue.ToString());
        giftsTemplateTransform.Find("EXPValue").GetComponent<TextMeshProUGUI>().SetText(expValue.ToString());
        giftsTemplateTransform.Find("Icon").GetComponent<Image>().sprite = itemSprite;

        buttonSelect.GetComponent<Button>().onClick.AddListener(() =>
        {
            TryBuyItem(itemType);
        });
        
    } 

    public void TryBuyItem(Item.ItemType itemType)
    {
        Debug.Log("Button works");
    }

}

