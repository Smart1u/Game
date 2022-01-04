using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{
    public Pdamage Damage;
    public Health_Hero Hero;
    public Text YourPointText;
    public Playermove move;
    public Damage Damagelvl1;
    public Damage Damagelvl2;
    public Damage Damagelvl3;


    public Text SpeedUpText;
    public int speedlvl = 0;

    public int DamageRecoverylvl = 0;
    public Text DamageRecoveryText;

    public int Vampirismlvl = 0;
    public Text VampirismText;

    // Update is called once per frame
    void Update()
    {
        YourPointText.text = "ОЧКИ НАВЫКОВ:" + Hero.SkillPoint;
        SpeedUpText.text = "Скорость + 10%\n" + speedlvl + "/5";
        DamageRecoveryText.text = "Возврат урона + 5%\n" + DamageRecoverylvl + "/5";
        VampirismText.text = "Лечение за урон + 5%\n" + Vampirismlvl + "/10";
    }

    public void SpeedUpButton()
    {
        
        if (Hero.SkillPoint >= 1 && speedlvl != 5)
        {
            Hero.SkillPoint -= 1;
            speedlvl += 1;
            move.speedUp += 1;
        }
        else
        {  }
    }
    public void DamageRecoveryButton()
    {
        if(Hero.SkillPoint >= 1 && DamageRecoverylvl !=5)
        {
            Hero.SkillPoint -= 1;
            Damagelvl1.DamageReclvl += 1;
            Damagelvl1.DamageRecProcent += 5;
            Damagelvl2.DamageReclvl += 1;
            Damagelvl2.DamageRecProcent += 5;
            Damagelvl3.DamageReclvl += 1;
            Damagelvl3.DamageRecProcent += 5;
            DamageRecoverylvl += 1;
        }
        else
        {  }
    }
    public void VampirismButton()
    {
        if(Hero.SkillPoint >=1 && Vampirismlvl != 10)
        {
            Hero.SkillPoint -= 1;
            Vampirismlvl += 1;
            Damage.Vampirismlvl += 1;
            Damage.VampirismProcent += 5;
        }
        else 
        {  }
    }
}
