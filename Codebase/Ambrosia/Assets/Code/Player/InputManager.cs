using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct SPlayerInputs
{
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool attack;
    public bool skill;
    public bool quickSwap;
    public SPlayerInputs(SPlayerInputs inInput)
    {
        up = inInput.up;
        down = inInput.down;
        left = inInput.left;
        right = inInput.right;
        attack = inInput.attack;
        skill = inInput.skill;
        quickSwap = inInput.quickSwap;
    }

};
public class InputManager : MonoBehaviour
{
    SPlayerInputs playerInputs;
    // Use this for initialization
    void Start()
    {
        playerInputs.up = false;
        playerInputs.down = false;
        playerInputs.left = false;
        playerInputs.right = false;
        playerInputs.attack = false;
        playerInputs.skill = false;
        playerInputs.quickSwap = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region Set Input Booleans
        playerInputs.up = (Input.GetAxis("Vertical") > 0.0f) ? true : false;
        playerInputs.down = (Input.GetAxis("Vertical") < 0.0f) ? true : false;
        playerInputs.right = (Input.GetAxis("Horizontal") > 0.0f) ? true : false;
        playerInputs.left = (Input.GetAxis("Horizontal") < 0.0f) ? true : false;
        playerInputs.attack = (Input.GetAxis("Attack") > 0.0f) ? true : false;
        playerInputs.skill = (Input.GetAxis("Skill") > 0.0f) ? true : false;
        playerInputs.quickSwap = (Input.GetAxis("QuickSwap") > 0.0f) ? true : false;
        #endregion
    }

    public SPlayerInputs GetInputStatus()
    {
        return new SPlayerInputs(playerInputs);
    }
}
