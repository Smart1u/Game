using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QestVilage : MonoBehaviour
{

    public QestSpawn SpawnLVL3_1, SpawnLVL3_2, SpawnLVL3_3;
    public Qest qest;
    public int enemydead;
    public int enemymax;

    void  FixedUpdate()
    {
        enemymax = SpawnLVL3_1.enemymax + SpawnLVL3_2.enemymax + SpawnLVL3_3.enemymax;
        if (enemydead >=enemymax && qest.wave != 5 && qest.wave >=1)
        {
            qest.wave += 1;
            SpawnLVL3_1.enemymax += 1; SpawnLVL3_2.enemymax += 1; SpawnLVL3_3.enemymax += 1;
            SpawnLVL3_1.enemycount = 0; SpawnLVL3_2.enemycount = 0; SpawnLVL3_3.enemycount = 0;
            enemydead = 0;
            
        }
        else { }
    }
}
