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
    PlayerBuffs currentBuff;


    GameManager gm;


    // Use this for initialization
    void Start()
    {
        health = 9;
        maxHealth = 10;
        gm = FindObjectOfType<GameManager>();
        gm._entityManager.SetPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        SPlayerInputs input = gm._inputManager.GetInputStatus();
        if (input.downButtonDown)
        {
            health -= 1;
            gm._hudManager.SetHealthBarAmount((float)health / (float)maxHealth);
        }
        #region Refactor when done testing icon hotswapping

        if (input.attackPressed)
            currentBuff = PlayerBuffs.NO_BUFF;
        if (input.skillPressed)
            currentBuff = PlayerBuffs.FIRE_HASTE;

        switch (currentBuff)
        {

            case PlayerBuffs.NO_BUFF:
                gm._hudManager.SetSkillIcon(Resources.Load<GameObject>("UI/SkillIconNoBuff").GetComponent<UnityEngine.UI.RawImage>());

                break;
            case PlayerBuffs.FIRE_HASTE:
                gm._hudManager.SetSkillIcon(Resources.Load<GameObject>("UI/SkillIconFire").GetComponent<UnityEngine.UI.RawImage>());
                break;

            default:
                break;
        }
        #endregion
    }
}
