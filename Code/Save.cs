using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class Save : MonoBehaviour
{
    public GameObject Player;
    public Health_Hero hero;
    public SkillPanel skills;
    public Shop shop;
    public Pdamage pdamage;
    public GameObject Camera;
    public Qest q;
    [System.Serializable]
    public class Position
    {
        public float x, y, z; // сохранение позиции игрока

        public float xr, yr, zr, wr, xcam; // сохранение поворота камеры

        public int mexp, exp;
        public int health, maxhealth;
        public int level;
        public int money;
        public int skillpoint;
        public int armor;

        public int vampirskill;
        public int speedskill;

        public int swordp, armorp; // стоимость прокачки в магазине

        public int playerdamage;

        public bool win;
    }

    public void Saves()
    {
        Position position = new Position();

        position.x = Player.transform.position.x;
        position.y = Player.transform.position.y;
        position.z = Player.transform.position.z;

        position.xr = Player.transform.rotation.x;
        position.yr = Player.transform.rotation.y;
        position.zr = Player.transform.rotation.z;
        position.wr = Player.transform.rotation.w;
        position.xcam = Camera.transform.rotation.x;

        position.skillpoint = hero.SkillPoint;
        position.money = hero.HeroMoney;
        position.mexp = hero.maxexp;
        position.exp = hero.Expirience;
        position.maxhealth = hero.MaxHealthHero;
        position.health = hero.HealthHero;
        position.level = hero.levelHero;
        position.armor = hero.Armor;

        position.vampirskill = skills.Vampirismlvl;
        position.speedskill = skills.speedlvl;

        position.swordp = shop.PriceSword;
        position.armorp = shop.ArmorPrice;

        position.playerdamage = pdamage.Damage;

        position.win = q.win;
        
        if (!Directory.Exists(Application.dataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.dataPath + "/saves");
        }
        FileStream fs = new FileStream(Application.dataPath + "/saves/save1.sv", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, position);
            fs.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.dataPath + "/saves/save1.sv"))
        {
            FileStream fs = new FileStream(Application.dataPath + "/saves/save1.sv", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                Position pos = (Position)formatter.Deserialize(fs);
                Player.SetActive(false);

                pdamage.Damage = pos.playerdamage;

                skills.speedlvl = pos.speedskill;
                skills.Vampirismlvl = pos.vampirskill;

                shop.ArmorPrice = pos.armorp;
                shop.PriceSword = pos.swordp;

                hero.Armor = pos.armor;
                hero.SkillPoint = pos.skillpoint;
                hero.HeroMoney = pos.money;
                hero.maxexp = pos.mexp;
                hero.Expirience = pos.exp;
                hero.MaxHealthHero = pos.maxhealth;
                hero.HealthHero = pos.health;
                hero.levelHero = pos.level;
                q.win = pos.win;
                Player.transform.position = new Vector3(pos.x, pos.y, pos.z);
                Player.transform.rotation = new Quaternion(pos.xr, pos.yr, pos.zr, pos.wr);
                Camera.transform.rotation = new Quaternion(0, 0, 0, 0);
                Player.SetActive(true);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }
            finally
            {
                fs.Close();
                
            }
        }
    }
}
