using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //These are the class "PlayerController's" member variables.
    #region PlayerVariables
    #region Physics 
    public float vertVelocity;
    public float horizVelocity;
    public float weight;
    public float frictionCoefficent;
    public float gravityAccel;
    public float runAccel;
    public float maxFallSpeed;
    public float maxRunSpeed;
    public float jumpPower;

    public bool grounded;
    #endregion
    #region ButtonMasks
    //These are turned on for the frame where a player Pressed the button, but off otherwise (including holding down the button)
    bool jumpButton;
    //These are turned on or off if the button is held. These are this way to enable controller support, where the directions arent buttons.
    bool leftButton;
    bool rightButton;
    bool upButton;
    bool downButton;
    #endregion
    #region Controllability
    bool airJump;
    #endregion
    #region External Objects
    //This array keeps track of all objects we're in contact with
    List<GameObject> currentCollisions;
    #endregion
    #endregion



    // Use this for initialization
    void Start()
    {
        #region Initialize Player Variables
        #region Physics Variables
        vertVelocity = 0.0f;
        horizVelocity = 0.0f;


        grounded = false;
        #endregion
        #region Controllability
        airJump = true;
        #endregion
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

        #region Set Button Masks
        jumpButton = Input.GetButtonDown("Jump");
        rightButton = Input.GetAxis("Horizontal") > 0;
        leftButton = Input.GetAxis("Horizontal") < 0;
        upButton = Input.GetAxis("Vertical") > 0;
        downButton = Input.GetAxis("Vertical") < 0;
        #endregion




        if (!grounded)
        #region Air physics
        {
            //Apply gravity
            vertVelocity -= weight * gravityAccel;
            if (vertVelocity < maxFallSpeed)
            {
                vertVelocity = maxFallSpeed;
            }
        }
        #endregion
        else
        #region Ground Physics
        {
            #region Friction
            if (!rightButton && !leftButton)//We aren't moving left or right
            {


                int direction = (int)CustomMathFunctions.ReturnSign(horizVelocity);
                horizVelocity -= direction * frictionCoefficent;

                if (direction > 0 && horizVelocity < 0)
                    horizVelocity = 0;

                if (direction < 0 && horizVelocity > 0)
                    horizVelocity = 0;

            }



            #endregion
        }
        #endregion


        #region Controlling
        #region Jumping
        if (jumpButton && grounded)
        {

            vertVelocity += jumpPower;

        }
        else if (jumpButton && !grounded && airJump)
        {

            vertVelocity = 0.0f;//We set it to 0 because it feels better to just instantly get full force jumps
            vertVelocity += jumpPower;
            airJump = false;
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

        //Apply motion
        transform.Translate(Vector3.right * horizVelocity * Time.deltaTime);
        transform.Translate(Vector3.up * vertVelocity * Time.deltaTime);


    }




    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform")
        {

            if (transform.position.y >= collision.gameObject.transform.position.y)//If this is true, we have landed
            {
                grounded = true;
                vertVelocity = 0.0f;
                airJump = true;

            }

            else
                grounded = false;

        }
        else
            grounded = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform")
        {
            grounded = false;

        }
    }
}
