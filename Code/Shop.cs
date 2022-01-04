using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public Text PriceSwordText; // Текст Стоимости меча
    public int PriceSword = 100; // Цена Меча
    public Health_Hero MoneyPrice; // Переменная других переменных Health_Hero
    public Pdamage DamageShop; // Переменная Урона игрока
    public Text YourMoney; // Текст денег игрока
    public camera Sens; // Переменная Чувствительности камеры игрока
    public int Priceheal = 500;
    public AttackPlyer hit;
    public GameObject shopmenu;
    public bool shopactive;
    public int a = 0;
    public int ArmorPrice = 1000;
    public Text PriceArmorText;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PriceSwordText.text = "Цена:" + PriceSword + " $"; // Отображает стоимость Прокачки Меча
        YourMoney.text = "$: " + MoneyPrice.HeroMoney; // Отображает Деньги персонажа в магазине
        PriceArmorText.text = "Цена:" + ArmorPrice + " $";
    }

    public void UpgradeSword() //Создание метода
    {
        if (MoneyPrice.HeroMoney >= PriceSword) // Сравнивает Цену в магазине и деньги игрока
        {
            MoneyPrice.HeroMoney -= PriceSword; // деньги грока - цена улучшения
            DamageShop.Damage += 5; // Прибавляет Урон Персонажу
            PriceSword += 100; // Поднимает цену улучшения на 100
        }
        else
        {
            // Ничего не делает
        }
    }

    public void UpgradeArmor()
    {
        if(MoneyPrice.HeroMoney >= ArmorPrice)
        {
            MoneyPrice.Armor += 5;
            MoneyPrice.HeroMoney -= ArmorPrice;
            ArmorPrice += 500;
        }
        else { }
    }

    public void ClouseShop() // Создание метода
    {
        shopactive = false;
        shopmenu.SetActive(false); // Меню перестаёт отображаться
        Cursor.lockState = CursorLockMode.Locked; // Курсор заблокировать
        UnityEngine.Cursor.visible = false; // Курсор Скрыть
        Time.timeScale = 1f; // Скорость игры = 1
        Sens.mouseSens = 6; // Устанавливает Чувствительность мыши камеры на 6
        hit.menu = false;
        a = 0;
    }
    public void HealHero()
    {
        if (MoneyPrice.HeroMoney >= Priceheal && MoneyPrice.HealthHero != MoneyPrice.MaxHealthHero)
        {
            MoneyPrice.HeroMoney -= Priceheal;
            MoneyPrice.HealthHero = MoneyPrice.MaxHealthHero;
        }
        else
        {

        }
    }

}
