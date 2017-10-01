using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region PlayerVariables
    #region Physics 
    public float vertVelocity;
    public float horizVelocity;
    public float weight;
    public float gravityAccel;
    public float runAccel;
    public float maxFallSpeed;
    public float maxRunSpeed;
    public float jumpPower;

    public bool grounded;
    #endregion
    #region Controllability
    bool airJump;
    #endregion
    #endregion

    //Hi Brennan this is a test. 

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

        }
        #endregion


        #region Controlling
        #region Jumping
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("Jumping");
            vertVelocity += jumpPower;

        }
        else if (Input.GetButtonDown("Jump") && !grounded && airJump)
        {
            Debug.Log("Double Jumping");
            vertVelocity = 0.0f;//We set it to 0 because it feels better to just instantly get full force jumps
            vertVelocity += jumpPower;
            airJump = false;
        }//No else, because if we arent grounded and we dont have an air jump, we can't jump
        #endregion
        #region Running
        if (Input.GetAxis("Horizontal") > 0)
        {
            Debug.Log("Moving right");
            horizVelocity += runAccel;
            if (horizVelocity > maxRunSpeed)
            {
                horizVelocity = maxRunSpeed;
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Debug.Log("Moving left");
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
        if (collision.gameObject.tag == "Floor")
        {

            if (transform.position.y >= collision.gameObject.transform.position.y)//If this is true, we have landed
            {
                Debug.Log("Landed");
                Debug.Log(transform.position);
                Debug.Log("Object: " + collision.gameObject.transform.position);
                grounded = true;
                vertVelocity = 0.0f;
                airJump = true;//New test
            }

            else
                grounded = false;

        }
        else
            grounded = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            grounded = false;
            Debug.Log("Leaving ground");
        }
    }
}
