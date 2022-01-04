using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pdamage : MonoBehaviour
{
    public void Update()
    {
        if(Vampirismlvl >= 1)
        {
            Vampirism = ((Damage * VampirismProcent) / 100);
        }
        else { }
    }
    public int Damage = 10; 
    public Health_Hero Hero;
    public SkillPanel Skill;
    public int max = 1;
    public int Vampirism;
    public int Vampirismlvl = 0;
    public int VampirismProcent = 0;
    void OnTriggerEnter(Collider MyCollider) 
    {
        if(MyCollider.tag == ("Enemy")) 
        {
            MyCollider.GetComponent<Enemy>().HealthEnemy -= Damage; 
            
            Hero.HealthHero += Vampirism;
        }
        if (MyCollider.tag == ("EnemyQ")) 
        {
            MyCollider.GetComponent<BanditEnemyQest>().HealthEnemy -= Damage;
           
            Hero.HealthHero += Vampirism;
        }
        if (MyCollider.tag == ("EnemyKQ")) 
        {
            MyCollider.GetComponent<KnightEnemyQest>().HealthEnemy -= Damage;
            Hero.HealthHero += Vampirism;
        }
        if (MyCollider.tag == ("EnemyAV")) 
        {
            MyCollider.GetComponent<AttackVilageBandit>().HealthEnemy -= Damage;

            Hero.HealthHero += Vampirism;
        }
    }
}