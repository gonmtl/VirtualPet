using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHappiness = 100;
    public float currentHappiness;
    public float happinessDecreaseRate;
    [SerializeField]
    public Happiness_Bar happinessBar;

    void Start()
    {
        // _happinessBar = GameObject.Find("Happiness_Bar").GetComponent<Happiness_Bar>();

        // if (_happinessBar == null)
        // {
        //   Debug.LogError("Happiness Bar is NULL");
        // }

        currentHappiness = maxHappiness;
        happinessBar.SetMaxHappiness(maxHappiness);
        happinessDecreaseRate = 5.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Sacar 10");
            TakeHappiness(10);
        }

        if (currentHappiness >= 0)
        {
            currentHappiness -= Time.deltaTime * happinessDecreaseRate;
            TakeHappiness(currentHappiness);
        }
    }

    public void TakeHappiness(float happiness)
    {
        happinessBar.UpdateHappiness(currentHappiness);
    }
    

}
