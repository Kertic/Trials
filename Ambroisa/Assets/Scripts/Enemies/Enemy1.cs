using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : PlayerController {
    int enemy1_Timer;
    // Use this for initialization
    void Start() {
        base.Start();
        enemy1_Timer = 0;
	}
    private void FixedUpdate()
    {
        base.FixedUpdate();
    }
    // Update is called once per frame
    void Update() {
        if (enemy1_Timer < 240)
        {
            enemy1_Timer += 1;
        }
        else
        {
            enemy1_Timer = 0;
        }
        jumpButton = false;
        upButton = false;
        downButton = true;
        if (enemy1_Timer <= 120)
        {
            leftButton = true;
            rightButton = false;
        }
        else
        {
            leftButton = false;
            rightButton = true;
        }
        #region Controlling
        #region Jumping
        if (jumpButton && !grounded && airJumps > 0)
        {

            vertVelocity = 0.0f;//We set it to 0 because it feels better to just instantly get full force jumps
            vertVelocity += jumpPower;
            airJumps -= 1;


        }
        else if (jumpButton && grounded)
        {
            vertVelocity += jumpPower;


        }//No else, because if we arent grounded and we dont have an air jump, we can't jump
        #endregion
        #region Climb/Decending
        if (downButton)
        {
            GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
            for (int i = 0; i < platforms.Length; i++)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), platforms[i].GetComponent<Collider2D>(), true);
            }

        }
        else
        {
            GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
            for (int i = 0; i < platforms.Length; i++)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), platforms[i].GetComponent<Collider2D>(), false);
            }
        }
        #endregion
        #region Running
        if (rightButton)
        {
            if (horizVelocity < 0)
                horizVelocity = 0;


            horizVelocity += runAccel;
            if (horizVelocity > maxRunSpeed)
            {
                horizVelocity = maxRunSpeed;
            }
        }
        else if (leftButton)
        {
            if (horizVelocity > 0)
                horizVelocity = 0;

            horizVelocity -= runAccel;
            if (horizVelocity < (0.0f - maxRunSpeed))
            {
                horizVelocity = (0.0f - maxRunSpeed);
            }
        }
        #endregion
        #endregion


    }
}
