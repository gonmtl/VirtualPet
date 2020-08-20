using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ModalMoveEase : MonoBehaviour
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
        LeanTween.moveY(gameObject, 400f, 0.6f).setEaseOutSine();
        isOpen = true;
    }
    public void moveModalOut()
    {
        LeanTween.moveY(gameObject, -400f, 0.3f).setEaseInSine();
        isOpen = false;
    }
}
