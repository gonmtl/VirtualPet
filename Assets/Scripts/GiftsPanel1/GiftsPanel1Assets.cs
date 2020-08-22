using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftsPanel1Assets : MonoBehaviour
{
    private static GiftsPanel1Assets _i;

    public static GiftsPanel1Assets i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("GiftsPanel1Assets")) as GameObject).GetComponent<GiftsPanel1Assets>();

            return _i;
        }
    }

    public Sprite Cake;
}
