using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningModals : MonoBehaviour
{
    public bool isOpen = false;

    public void moveModal()
    {
        if (isOpen == false)
        {
            moveModalIn();
        }
        else
        {
            moveModalOut();
        }
    }

    public void moveModalIn()
    {
        // LeanTween.moveY(gameObject, 400f, 0.6f).setEaseOutSine();
        gameObject.SetActive(true);
        isOpen = true;
    }
    public void moveModalOut()
    {
        // LeanTween.moveY(gameObject, -400f, 0.3f).setEaseInSine();
        gameObject.SetActive(false);
        isOpen = false;
    }
}
