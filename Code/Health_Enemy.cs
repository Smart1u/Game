using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Enemy : MonoBehaviour
{
    public int HealthEnemy = 100;
    public int HealthEnemyMax = 100;
    public Slider mySlider;
    public Image myImage;
    public GameObject HealthBarUI;

    void Start()
    {
        HealthEnemy = HealthEnemyMax;
        mySlider.value = HealthEnemy;
    }

    void Update()
    {
        mySlider.value = CalculateHealth();

        if (HealthEnemy < HealthEnemyMax)
        {
            HealthBarUI.SetActive(true);
        }
        if (HealthEnemy <= 0)
        {
            Destroy(gameObject);
        }
        if (HealthEnemy > HealthEnemyMax)
        {
            HealthEnemy = HealthEnemyMax;
        }
        mySlider.value = HealthEnemy;
        if(HealthEnemy < 1)
        {
            myImage.enabled = false;
        }
        else
        {
            myImage.enabled = true;
        }


        
      

    }
    int CalculateHealth()
    {
        return HealthEnemy / HealthEnemyMax;
    }
}

