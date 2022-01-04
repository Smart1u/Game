using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Damage : MonoBehaviour
{
    public void Update()
    {
       if(DamageReclvl >= 1)
       {
            RecoveryDamage = ((Edamage * DamageRecProcent) / 100);
       }
        else { }
    }
    public int RecoveryDamage = 10;
    public int max = 1;
    public int Edamage = 10; 
    public Health_Hero Hero;
    public SkillPanel Skill;
    public Enemy health;
    public int DamageReclvl = 0;
    public int DamageRecProcent = 0;

    void OnTriggerEnter(Collider MyCollider) 
    {
        if(MyCollider.tag == ("Player")) 
        {
            
            MyCollider.GetComponent<Health_Hero>().HealthHero -= (Edamage - Hero.Armor); 
            
        }
        if (MyCollider.tag == ("Target2")) 
        {

            MyCollider.GetComponent<VilageHealth>().Healthvilage -=Edamage ; 

        }
    }
}




