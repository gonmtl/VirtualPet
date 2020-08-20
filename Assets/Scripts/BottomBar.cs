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
            Animator animator = giftsPanel.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
            }
        }
    }
}
