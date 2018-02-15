using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{


    struct SPlayerInputs
    {
        public bool up;
        public bool down;
        public bool left;
        public bool right;

        public bool attack;
        public bool skill;

        public bool quickSwap;

    };
    SPlayerInputs playerInputs;

    // Use this for initialization
    void Start()
    {
        #region Initialize Input bools
        playerInputs.up = false;
        playerInputs.down = false;
        playerInputs.left = false;
        playerInputs.right = false;
        playerInputs.attack = false;
        playerInputs.skill = false;
        playerInputs.quickSwap = false; 
        #endregion
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
}
