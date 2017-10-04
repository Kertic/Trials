using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialPlayer : MonoBehaviour {

    #region tutorialPlayer Member Variables

    //Variables made here exist across all instances of the class "tutorialPlayer"
    //You can use these to track data related to this object

    #region Physics
    //Here we'll put any member variables related to physics
    float xVelocity;
    float yVelocity;
    bool grounded;
    #endregion


    #endregion



    // Use this for initialization
    void Start () {
        //Here, we will make sure to initialize any variables we dont specify in the editor

        #region Physics
        xVelocity = 0.0f;//0.0f is "float" format. "int" format has no decimals (0,4,12313) and "double" format has a decimal but no f (0.0, 0.2, 0.0332).
        yVelocity = 0.0f;//We use floats for decimal math because they are much, much faster than doubles. Doubles are precise enough for medical science, and floats aren't.
        #endregion

    }

    // Update is called once per frame
    void Update () {
        //This is the majority of our logic
        //Any calculations or modifications must be done here

        //I've already created some collision logic, so when your character touches the box, their vertical velocity will be set to 0.0f and the mysterious "Grounded" variable will be set to true.

        #region Make the character move up
        //Part1: Make them move up at all.
        //Part2: Make them move up when the input button "Jump" is pressed
        //Part3: Make them stop moving when jump isn't pressed
        //Part4: Make them be affected by gravity
        #endregion

        #region Make the character move left or right
        //Part1: Make the character move left, and then change your code so they move right
        //Part2: Make the character move left when the left button is pressed, and right when the right button is pressed. 
        //Hint: The input for this is called "Horizontal" and even though its pressed with keys, Unity interprets it as an "axis" with positive value and negitive values.
        //Part3: Make them come to a stop when they stop moving.
        #endregion



        //These commands basically read: Move our characters position (up/right) equal to our velocity.
        transform.Translate(Vector3.up * yVelocity * Time.deltaTime);
        transform.Translate(Vector3.right * xVelocity * Time.deltaTime);
		
	}


    //Feel free to look under here, but this manages collision. Essentially, when you collide with the box, it will set your "Grounded" variable to true and your vertical velocity to 0.0f
    #region Under the Hood
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform")
        {

            if (transform.position.y >= collision.gameObject.transform.position.y)//If this is true, we have landed
            {
                grounded = true;
                yVelocity = 0.0f;
               

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
    #endregion
}
