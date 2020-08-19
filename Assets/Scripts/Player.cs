using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHappiness = 100;
    public float currentHappiness;
    // public float happinessDecreaseRate;
    public float hourToDecrease;
    public float hourQuantity;
    public float totalTime;

    [SerializeField]
    public Happiness_Bar happinessBar;

    void Start()
    {
        currentHappiness = PlayerPrefs.GetFloat("HappinessValue", maxHappiness);
        happinessBar.SetMaxHappiness(maxHappiness);
        // happinessDecreaseRate = 0.00463f;
        // hourToDecrease = 100/3600;
        hourToDecrease = 0.02777777777f;
        hourQuantity = 1.00f; // cambiar a 12 horas despues en produccion
        totalTime = hourToDecrease / hourQuantity;
    }

    void Update()
    {

        PlayerPrefs.SetFloat("HappinessValue", currentHappiness);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Sacar 10");
            HappinessDecay(10f);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Agregar 10");
            AddHappiness(20f);
        }

        if (currentHappiness >= 0)
        {
            currentHappiness -= Time.deltaTime * (totalTime * 1); // 6 horas * 60 lo hace 1 minuto (cambiarlo a horas despues)
            HappinessDecay(currentHappiness);
        }
    }

    public void HappinessDecay(float happiness)
    {
        happinessBar.UpdateHappiness(currentHappiness);
    }

    public void AddHappiness(float happiness)
    {
        currentHappiness += happiness;
    }
    

}
