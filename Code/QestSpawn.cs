using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QestSpawn : MonoBehaviour
{
    public GameObject Enemy; 
    public int enemycount; 
    public int enemymax = 20;
    public float rangespawnMinX = 51.03f, rangespawnMaxX = 105f;
    public float rangespawnvertivalMinZ = 75.35f, rangespawnvertivalMaxZ = 100f;
    public float y = 8.3f;
    public int Qestenemycount = 0;
    void FixedUpdate()
    {
        if (enemycount < enemymax) 
        {
            Enemy.SetActive(true); 
            Vector3 position = new Vector3(Random.Range(rangespawnMinX, rangespawnMaxX), y, Random.Range(rangespawnvertivalMinZ, rangespawnvertivalMaxZ)); 
            Instantiate(Enemy, position, Quaternion.identity); 
            enemycount += 1; 
        }
    }
}
