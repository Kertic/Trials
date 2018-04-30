using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct SPlayerInputs
{
    public bool upPressed;
    public bool downPressed;
    public bool leftPressed;
    public bool rightPressed;
    public bool attackPressed;
    public bool skillPressed;
    public bool quickSwapPressed;

    public bool upButtonDown;
    public bool downButtonDown;
    public bool leftButtonDown;
    public bool rightButtonDown;
    public bool attackButtonDown;
    public bool skillButtonDown;
    public bool quickSwapButtonDown;
    public SPlayerInputs(SPlayerInputs inInput)
    {
        upPressed = inInput.upPressed;
        downPressed = inInput.downPressed;
        leftPressed = inInput.leftPressed;
        rightPressed = inInput.rightPressed;
        attackPressed = inInput.attackPressed;
        skillPressed = inInput.skillPressed;
        quickSwapPressed = inInput.quickSwapPressed;

        upButtonDown = inInput.upButtonDown;
        downButtonDown = inInput.downButtonDown;
        leftButtonDown = inInput.leftButtonDown;
        rightButtonDown = inInput.rightButtonDown;
        attackButtonDown = inInput.attackButtonDown;
        skillButtonDown = inInput.skillButtonDown;
        quickSwapButtonDown = inInput.quickSwapButtonDown;
    }

};
public class InputManager : MonoBehaviour
{
    SPlayerInputs pi;

    bool[] hasBeenReleased;
    // Use this for initialization
    void Start()
    {
        pi.upPressed = false;
        pi.downPressed = false;
        pi.leftPressed = false;
        pi.rightPressed = false;
        pi.attackPressed = false;
        pi.skillPressed = false;
        pi.quickSwapPressed = false;

        pi.upButtonDown = false;
        pi.downButtonDown = false;
        pi.leftButtonDown = false;
        pi.rightButtonDown = false;
        pi.attackButtonDown = false;
        pi.skillButtonDown = false;
        pi.quickSwapButtonDown = false;
        hasBeenReleased = new bool[7];
    }

    // Update is called once per frame
    void Update()
    {

        #region Set Input Booleans
        pi.upPressed = (Input.GetAxis("Vertical") > 0.0f) ? true : false;
        pi.downPressed = (Input.GetAxis("Vertical") < 0.0f) ? true : false;
        pi.rightPressed = (Input.GetAxis("Horizontal") > 0.0f) ? true : false;
        pi.leftPressed = (Input.GetAxis("Horizontal") < 0.0f) ? true : false;
        pi.attackPressed = (Input.GetAxis("Attack") > 0.0f) ? true : false;
        pi.skillPressed = (Input.GetAxis("Skill") > 0.0f) ? true : false;
        pi.quickSwapPressed = (Input.GetAxis("QuickSwap") > 0.0f) ? true : false;




        pi.upButtonDown = (pi.upPressed && Input.GetButtonDown("Vertical")) ? true : false;
        pi.downButtonDown = (pi.downPressed && Input.GetButtonDown("Vertical")) ? true : false;
        pi.rightButtonDown = (pi.rightPressed && Input.GetButtonDown("Horizontal")) ? true : false;
        pi.leftButtonDown = (pi.leftPressed && Input.GetButtonDown("Horizontal")) ? true : false;
        pi.attackButtonDown = (pi.attackPressed && Input.GetButtonDown("Attack")) ? true : false;
        pi.skillButtonDown = (pi.skillPressed && Input.GetButtonDown("Skill")) ? true : false;
        pi.quickSwapButtonDown = (pi.quickSwapPressed && Input.GetButtonDown("QuickSwap")) ? true : false;
        #endregion
    }

    public SPlayerInputs GetInputStatus()
    {
        return new SPlayerInputs(pi);
    }
}
