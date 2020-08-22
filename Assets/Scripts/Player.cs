using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Player : MonoBehaviour
{

    // Handles
    [SerializeField]
    public Happiness_Bar happinessBar;
    [SerializeField]
    public SakuraCounter sakuraCounter;
    [SerializeField]
    public SakuraCounter goldenSakuraCounter;


    // Happiness Variables
    public float maxHappiness = 100.0f;
    public float currentHappiness;
    public float hourToDecrease;
    public float hourQuantity;
    public float secondsQuantity;
    public float totalTime;

    // Sakura Variables
    public int sakuraAmount;

    // Golden Sakura Variables
    public int goldenSakuraAmount;

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

        if (oldDate == null)
        {
            oldDate = System.DateTime.Now;
        }

        TimeSpan getDifference = currentDate.Subtract(oldDate);  
        difference = (float)getDifference.TotalSeconds;
        

        // Getting Sakura Amount from PlayerPrefs

        sakuraAmount = PlayerPrefs.GetInt("SakuraAmount", 0);
        goldenSakuraAmount = PlayerPrefs.GetInt("GoldenSakuraAmount", 0);


        // Initializing happiness

        currentHappiness = PlayerPrefs.GetFloat("HappinessValue", maxHappiness); // Loads happiness
        happinessBar.SetMaxHappiness(maxHappiness); // Send to UI

        // Initializing decay time

        hourToDecrease = 0.02777777777f;
        hourQuantity = 1.00f; // cambiar a 12 horas despues en produccion
        totalTime = hourToDecrease / hourQuantity;

        secondsQuantity = hourQuantity * 3600f;
        happinessDuringSleep = (maxHappiness / secondsQuantity) * difference;
        

        
        // Substract happiness on sleep to actual happiness
        currentHappiness -= happinessDuringSleep;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Sacar 10");
            SubstractHappiness(20f);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Agregar 10");
            AddHappiness(20f);
        }

        if (currentHappiness >= 0)
        {
            currentHappiness -= Time.deltaTime * totalTime; // 6 horas * 60 lo hace 1 minuto (cambiarlo a horas despues)
            UpdateHappiness(currentHappiness);
        }

        if (currentHappiness >= maxHappiness)
        {
            currentHappiness = maxHappiness;
        }

        if (currentHappiness < 0)
        {
            currentHappiness = 0;
        }

        updateSakuraCounter(sakuraAmount);
        updateGoldenSakuraCounter(goldenSakuraAmount);
    }

    public void UpdateHappiness(float happiness)
    {
        happinessBar.UpdateHappiness(currentHappiness);
    }

    public void AddHappiness(float happiness)
    {
        currentHappiness += happiness;
    }

    public void SubstractHappiness(float happiness)
    {
        currentHappiness -= happiness;
    }

    public void updateSakuraCounter(int sakura)
    {
        sakuraCounter.UpdateSakuraCounter(sakura.ToString());
    }

    public void updateGoldenSakuraCounter(int sakura)
    {
        sakuraCounter.UpdateGoldenSakuraCounter(sakura.ToString());
    }

    public void AddSakura(int sakura)
    {
        sakuraAmount += sakura;
    }

    public void SubstractSakura(int sakura)
    {

        if (sakuraAmount <= 0)
        {
            sakuraAmount = 0;
            sakura = 0;
        }

        sakuraAmount -= sakura;
    }

    public void AddGoldenSakura(int sakura)
    {
        goldenSakuraAmount += sakura;
    }

    public void SubstractGoldenSakura(int sakura)
    {
        if (goldenSakuraAmount <= 0)
        {
            goldenSakuraAmount = 0;
            sakura = 0;
        }

        goldenSakuraAmount -= sakura;

        
    }

    public void OnApplicationQuit()
    {
        // SAVE DATETIME
        PlayerPrefs.SetFloat("HappinessValue", currentHappiness);
        PlayerPrefs.SetString("sysTimeString", System.DateTime.Now.ToBinary().ToString());
        Debug.Log("Guardando esto al cerrar: " + System.DateTime.Now);

        //SAVE SAKURA AMOUNT
        PlayerPrefs.SetInt("SakuraAmount", sakuraAmount);
        PlayerPrefs.SetInt("GoldenSakuraAmount", goldenSakuraAmount);

        PlayerPrefs.Save();
    }

}
