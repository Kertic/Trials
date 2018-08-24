using System.Collections.Generic;
using Code.Entities.Player;
using Code.UI;
using UnityEngine;

namespace Code.GameManager
{
    public class GameManager : MonoBehaviour
    {
        public InputManager _inputManager;
        public HudManager _hudManager;
        private List<Enemy> _enemies;
        private Player[] _playerList;

    
        public delegate void PlayerHealthUpdate(int index);
        public static PlayerHealthUpdate PlayerHealthDelegate;

        public delegate void PlayerMoveUpdate(int index);
        public static PlayerMoveUpdate PlayerMoveDelegate;

        // Use this for initialization
        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {

        }


        public void SetPlayer(Player inPlayer, int playerIndex)
        {
            if (_playerList == null)
                _playerList = new Player[4];

            if (playerIndex < 4)
                _playerList[playerIndex] = inPlayer;
        }
        public void RemoveEnemy(Enemy enemyToRemove)
        {
            _enemies.Remove(enemyToRemove);
        }
        public int AddEnemy(Enemy inEn)
        {
            if (_enemies == null)
                _enemies = new List<Enemy>();
            _enemies.Add(inEn);
            return inEn.Id;
        }
        public void ClearEnemies() { _enemies.Clear(); }

        public Player GetPlayer(int index)
        {
            return _playerList[index];
        }
    }
}
