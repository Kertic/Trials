using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{

    List<Enemy> enemies;
    Player player;
    // Use this for initialization
    void Start()
    {
        enemies = new List<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayer(Player inPlayer)
    {
        player = inPlayer;
    }
    public bool RemoveEnemy(int enemyToRemove)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].Id == enemyToRemove)
            {
                enemies.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
    public int AddEnemy(Enemy inEn)
    {
        enemies.Add(inEn);
        return inEn.Id;
    }
    public void ClearEnemies() { enemies.Clear(); }
}
