using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Health_Hero : MonoBehaviour 
{
    public int MaxHealthHero = 100, HealthHero = 100, SkillPoint = 0, Armor = 0, HeroMoney;
    public Slider mySlider, myexpbank;   
    public Image myImage, myexp;   
    public int levelHero = 1, Expirience = 0, maxexp = 500; 
    public Text level, HealthCount, ExpCount, TextMoney; 
    
    void Update()   
    {
        TextMoney.text = "$:" + HeroMoney; 
        ExpCount.text = Expirience + " / " + maxexp; 
        HealthCount.text = HealthHero + " / " + MaxHealthHero; 
        level.text = "Уровень:" + levelHero; 
        myexpbank.maxValue = maxexp; 
        myexpbank.value = Expirience; 
        mySlider.value = HealthHero;  
        mySlider.maxValue = MaxHealthHero; 

        if(HealthHero > MaxHealthHero) 
        {
            HealthHero = MaxHealthHero; 
        }

        if (Expirience <= 0) 
        {
            myexp.enabled = false;   
        }
        else
        {
            myexp.enabled = true; 
        }

        if(Expirience >= maxexp) 
        {
            MaxHealthHero += 25; 
            HealthHero = MaxHealthHero; 
            levelHero += 1; 
            Expirience -= maxexp; 
            maxexp += 250; 
            SkillPoint += 1;
        }

        if (HealthHero <= 0)  
        {
            myImage.enabled = false;  
        }
        else
        {
            myImage.enabled = true;   
        }

    }
   
}
