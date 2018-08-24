using System.Collections;
using System.Collections.Generic;
using Code.GameManager;
using UnityEngine;

namespace Code.Entities.Player
{
    public enum PlayerBuffs
    {
        NO_BUFF,
        FIRE_HASTE,
        NUMOFPLAYERBUFFS
    };

    public class Player : MonoBehaviour
    {
        private int _health;
        private int _maxHealth;
        public int playerIndex;

        GameManager.GameManager _gm;


        // Use this for initialization
        void Start()
        {


            _health = 9;
            _maxHealth = 10;
            _gm = FindObjectOfType<GameManager.GameManager>();
            _gm.SetPlayer(this, playerIndex);

            switch (playerIndex)
            {
                case 0:
                    _gm.GetComponent<InputManager>().p1InputDelegate += RespondToInput;
                    break;
                case 1:
                    _gm.GetComponent<InputManager>().p2InputDelegate += RespondToInput;
                    break;
                case 2:
                    _gm.GetComponent<InputManager>().p3InputDelegate += RespondToInput;
                    break;
                case 3:
                    _gm.GetComponent<InputManager>().p4InputDelegate += RespondToInput;
                    break;
                default:
                    break;
            }
        }

        // Update is called once per frame
        void Update()
        {


        }
        void RespondToInput(InputTypes inputType, bool wasPressed)
        {
            switch (inputType)
            {
                case InputTypes.UP:
                    break;
                case InputTypes.DOWN:
                    break;
                case InputTypes.LEFT:
                    break;
                case InputTypes.RIGHT:
                    break;
                case InputTypes.ATTACK:

                    break;
                case InputTypes.SKILL1:
                    break;
                case InputTypes.SKILL2:
                    break;
                case InputTypes.SKILL3:
                    break;
                default:
                    break;
            }

        }
        void ChangeHealth(int amount)
        {
            _health += amount;
            GameManager.GameManager.PlayerHealthDelegate((int)playerIndex);
        }
        
        public int GetHealth() { return _health; }
        public int GetMaxHealth() { return _maxHealth; }

    }
}