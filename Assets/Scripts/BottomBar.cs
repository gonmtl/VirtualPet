using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBar : MonoBehaviour
{
    public GameObject giftsPanel;

    public void OpenGifts()
    {
        if (giftsPanel != null)
        {
            bool isActive = giftsPanel.activeSelf;
            giftsPanel.SetActive(!isActive);
        }
    }
}
