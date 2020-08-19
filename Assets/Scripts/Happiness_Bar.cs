using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Happiness_Bar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Update()
    {
        
    }

    public void SetMaxHappiness(int happiness)
    {
        slider.maxValue = happiness;
        slider.value = happiness;

        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetHappiness(int happiness)
    {
        // if (slider.value != happiness)
        // { 
        //    slider.value = Mathf.Lerp(slider.value, happiness, 1 * Time.deltaTime); 
        // }

        slider.value = happiness;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
