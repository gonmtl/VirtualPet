using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SakuraCounter : MonoBehaviour
{

    // Sakura Variables
    public Text SakuraText;

    // Golden Sakura Variables
    public Text GoldenSakuraText;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateSakuraCounter(string sakura)
    {
        SakuraText.text = sakura;
    }

    public void UpdateGoldenSakuraCounter(string goldenSakura)
    {
        GoldenSakuraText.text = goldenSakura;
    }
}
