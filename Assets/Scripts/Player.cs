using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : MonoBehaviour
{

    // Handles
    [SerializeField]
    public Happiness_Bar happinessBar;
    

    // Happiness Variables
    public float maxHappiness = 100;
    public float currentHappiness;
    public float hourToDecrease;
    public float hourQuantity;
    public float totalTime;

    // System clock and happiness
    public DateTime currentDate;
    public DateTime oldDate;
    public float difference;
    public float happinessDuringSleep;
    public float tempCurrentHappiness;



    void Start()
    {

        // Getting date difference from PlayerPrefs

        currentDate = System.DateTime.Now;
        long temp = Convert.ToInt64(PlayerPrefs.GetString("sysTimeString"));
        
        DateTime oldDate = DateTime.FromBinary(temp);
        Debug.Log("Old time: " + oldDate);

        if (oldDate == null)
        {
            oldDate = System.DateTime.Now;
        }

        TimeSpan getDifference = currentDate.Subtract(oldDate);
        Debug.Log("Diferencia: " + getDifference.TotalSeconds);
        difference = (float)getDifference.TotalSeconds;
        Debug.Log("Diferencia en float: " + difference);



        // Initializing happiness

        currentHappiness = PlayerPrefs.GetFloat("HappinessValue", maxHappiness); // Loads happiness
        happinessBar.SetMaxHappiness(maxHappiness);
        hourToDecrease = 0.02777777777f;
        hourQuantity = 1.00f; // cambiar a 12 horas despues en produccion
        totalTime = hourToDecrease / hourQuantity;
        currentHappiness -= 1.66666666667f * difference;

        // tempCurrentHappiness = totalTime;
        // tempCurrentHappiness = Time.deltaTime * difference;
        Debug.Log("VALOR DE FELICIDAD: " + 1.66666666667f * difference);
        Debug.Log("VALOR DE FELICIDAD: " + 0.13888888888f * difference);
        

        // currentHappiness -= tempCurrentHappiness;
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

            currentHappiness -= Time.deltaTime * (totalTime * 60); // 6 horas * 60 lo hace 1 minuto (cambiarlo a horas despues)
            HappinessDecay(currentHappiness);
        }

        if (currentHappiness >= maxHappiness)
        {
            currentHappiness = maxHappiness;
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

    public void OnApplicationQuit()
    {
        PlayerPrefs.SetString("sysTimeString", System.DateTime.Now.ToBinary().ToString());
        Debug.Log("Guardando esto al cerrar: " + System.DateTime.Now);
    }


}
