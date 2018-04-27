using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerBuffs
{
    NO_BUFF,
    FIRE_HASTE,
    NUMOFPLAYERBUFFS
};
public class PlayerStatus : MonoBehaviour
{
    GameObject gameManager;
    PlayerHudManager manager;
    SPlayerInputs playerInputs;

    float maxHealth;
    float currentHealth;
    PlayerBuffs currentBuff;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        currentBuff = PlayerBuffs.NO_BUFF;
        manager = gameManager.GetComponent<PlayerHudManager>();
        playerInputs = gameManager.GetComponent<InputManager>().GetInputStatus();
    }

    // Update is called once per frame
    void Update()
    {
        #region Refactor when done testing icon hotswapping
        playerInputs = gameManager.GetComponent<InputManager>().GetInputStatus();
        if (playerInputs.attack)
            currentBuff = PlayerBuffs.NO_BUFF;
        if (playerInputs.skill)
            currentBuff = PlayerBuffs.FIRE_HASTE;

        switch (currentBuff)
        {

            case PlayerBuffs.NO_BUFF:
                manager.SetSkillIcon(Resources.Load<GameObject>("UI/SkillIconNoBuff").GetComponent<UnityEngine.UI.RawImage>());
                break;
            case PlayerBuffs.FIRE_HASTE:
                manager.SetSkillIcon(Resources.Load<GameObject>("UI/SkillIconFire").GetComponent<UnityEngine.UI.RawImage>());
                break;

            default:
                break;
        } 
        #endregion


    }
}
