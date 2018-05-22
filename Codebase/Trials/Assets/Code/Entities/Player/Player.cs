using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Data types
public enum PlayerBuffs
{
    NO_BUFF,
    FIRE_HASTE,
    NUMOFPLAYERBUFFS
};
#endregion
public class Player : MonoBehaviour
{

    int health;
    int maxHealth;
    public uint playerIndex;

    GameManager gm;


    // Use this for initialization
    void Start()
    {


        health = 9;
        maxHealth = 10;
        gm = FindObjectOfType<GameManager>();
        gm.SetPlayer(this, playerIndex);

        switch (playerIndex)
        {
            case 0:
                gm.GetComponent<InputManager>().p1InputDelegate += RespondToInput;
                break;
            case 1:
                gm.GetComponent<InputManager>().p2InputDelegate += RespondToInput;
                break;
            case 2:
                gm.GetComponent<InputManager>().p3InputDelegate += RespondToInput;
                break;
            case 3:
                gm.GetComponent<InputManager>().p4InputDelegate += RespondToInput;
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
    void tempDamageMe()
    {
        health -= 1;
        GameManager.playerHudDelegate((int)playerIndex);
    }
    public int GetHealth() { return health; }
    public int GetMaxHealth() { return maxHealth; }

}
