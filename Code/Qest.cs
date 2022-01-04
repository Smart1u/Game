using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class Qest : MonoBehaviour
{
    public GameObject CompliteQestlvl1, CompliteQestlvl2, CompliteQestlvl3;
    public Health_Hero hero;
    public GameObject Objectivelvl1, Objectivelvl2, Objectivelvl3;
    public GameObject QestCanvas;
    public GameObject TakeQestlvl1, TakeQestlvl2, TakeQestlvl3;
    public camera Sens;
    public AttackPlyer hit;
    public int w = 0;
    public QestSpawn SpawnLVL1, SpawnLVL2;
    public QestSpawn SpawnLVL3_1, SpawnLVL3_2 , SpawnLVL3_3;
    public int enemydead, enemymax, wave = 0;
    public QestVilage vilage;
    public VilageHealth health;
    public GameObject slider;
    public bool win = false;
    public GameObject Winmenu;
    public void Update()
    {
        //1\\
        if (SpawnLVL1.Qestenemycount >= SpawnLVL1.enemymax)
        {
            Objectivelvl1.SetActive(false);
            CompliteQestlvl1.SetActive(true);
        }
        else { CompliteQestlvl1.SetActive(false); }
        //2\\
        if (SpawnLVL2.Qestenemycount >= SpawnLVL2.enemymax)
        {
            Objectivelvl2.SetActive(false);
            CompliteQestlvl2.SetActive(true);
        }
        else { CompliteQestlvl2.SetActive(false);  }
        //3\\
        enemymax = SpawnLVL3_1.enemymax + SpawnLVL3_2.enemymax + SpawnLVL3_3.enemymax;
        if(wave >=5)
        {
            Objectivelvl3.SetActive(false);
            CompliteQestlvl3.SetActive(true);
        }
        else { CompliteQestlvl3.SetActive(false); }
    }
    public void ClouseQestMenu() // закрыть меню
    {
        w = 0;
        QestCanvas.SetActive(false); 
        Cursor.lockState = CursorLockMode.Locked; 
        UnityEngine.Cursor.visible = false; 
        Time.timeScale = 1f; 
        Sens.mouseSens = 6; 
        hit.menu = false;
    }
    //1\\
    public void TakeQestLVL1() // взять 1 квест
    {
        SpawnLVL1.enemycount = 0;
        TakeQestlvl1.SetActive(false);
        Objectivelvl1.SetActive(true);
    }
    public void compliteQestLVL1() // завершить 1 квес
    {
        SpawnLVL1.Qestenemycount = 0;
        CompliteQestlvl1.SetActive(false);
        TakeQestlvl1.SetActive(true);
        hero.Expirience += 100;
        hero.HeroMoney += 150;
    }
    //2\\
    public void TakeQestLVL2()
    {
        SpawnLVL2.enemycount = 0;
        TakeQestlvl2.SetActive(false);
        Objectivelvl2.SetActive(true);
    }
    public void compliteQestLVL2()
    {
        SpawnLVL2.Qestenemycount = 0;
        CompliteQestlvl2.SetActive(false);
        TakeQestlvl2.SetActive(true);
        hero.Expirience += 250;
        hero.HeroMoney += 300;
    }
    //3\\
    public void TakeQestLVL3()
    {
        SpawnLVL3_1.enemycount = 0; SpawnLVL3_2.enemycount = 0; SpawnLVL3_3.enemycount = 0;
        TakeQestlvl3.SetActive(false);
        Objectivelvl3.SetActive(true);
        wave += 1;
        slider.SetActive(true);
    }
    public void compliteQestLVL3()
    {
        vilage.enemydead = 0;
        wave = 0;
        SpawnLVL3_1.enemymax = 0; SpawnLVL3_2.enemymax = 0; SpawnLVL3_3.enemymax = 0;
        SpawnLVL3_1.enemycount = 0; SpawnLVL3_2.enemycount = 0; SpawnLVL3_3.enemycount = 0;
        CompliteQestlvl3.SetActive(false);
        TakeQestlvl3.SetActive(true);
        hero.Expirience += 1000;
        hero.HeroMoney += 1000;
        health.Healthvilage = 2000;
        slider.SetActive(false);
        if (win != true)
        {
            Winmenu.SetActive(true);
            win = true;
        }
    }
}
