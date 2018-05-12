using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InputManager _inputManager;
    public HudManager _hudManager;
    List<Enemy> enemies;
    Player[] playerList;

    #region Delegates
    public delegate void PlayerHudUpdate(int index);
    static public PlayerHudUpdate playerHudDelegate;
    #endregion

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetPlayer(Player inPlayer, uint playerIndex)
    {
        if (playerList == null)
            playerList = new Player[4];

        if (playerIndex < 4)
            playerList[playerIndex] = inPlayer;
    }
    public void RemoveEnemy(Enemy enemyToRemove)
    {
        enemies.Remove(enemyToRemove);
    }
    public int AddEnemy(Enemy inEn)
    {
        if (enemies == null)
            enemies = new List<Enemy>();
        enemies.Add(inEn);
        return inEn.Id;
    }
    public void ClearEnemies() { enemies.Clear(); }

    public Player GetPlayer(uint index)
    {
        return playerList[index];
    }
}
