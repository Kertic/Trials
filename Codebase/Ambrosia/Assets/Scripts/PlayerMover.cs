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


    #region Physics variables
    Vector3 force;//Move by this much each frame 
    struct SPhysicsVariables
    {
        public bool grounded;
        public float groundFriction;
        public float airFriction;
        public float runSpeed;
        public float jumpHeight;
        public float gravity;
    }
    SPhysicsVariables physicsVariables;
    #endregion

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
        force = new Vector3(0.0f, 0.0f, 0.0f);
        #region Initialize Physics Variables
        physicsVariables.grounded = false;
        physicsVariables.groundFriction = 0.05f;
        physicsVariables.airFriction = 0.05f;
        physicsVariables.runSpeed = 0.2f;
        physicsVariables.jumpHeight = 0.2f;
        physicsVariables.gravity = -0.0098f;
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
    private void FixedUpdate()
    {
        if (physicsVariables.grounded)
        {
            force.y = 0.0f;//Set vertical motion to 0
            if (playerInputs.left)
            {
                force = new Vector3(-physicsVariables.runSpeed, force.y, force.z);//Hard set so there isnt any ramp up
            }
            if (playerInputs.right)
            {
                force = new Vector3(physicsVariables.runSpeed, force.y, force.z);//Hard set so there isnt any ramp up
            }
            if (playerInputs.up)
            {
                force += new Vector3(0.0f, physicsVariables.jumpHeight, 0.0f);
            }


            if (Mathf.Abs(force.x) < physicsVariables.groundFriction)
                force.x = 0.0f;

            if (force.x != 0)
                force += new Vector3(-physicsVariables.groundFriction * (force.x / Mathf.Abs(force.x)), 0.0f, 0.0f);

        }
        else//Not grounded
        {
            float groundAirRatio = physicsVariables.groundFriction / physicsVariables.airFriction;
            if (playerInputs.left)
            {
                force = new Vector3(-physicsVariables.runSpeed * groundAirRatio, force.y, force.z);//Hard set so there isnt any ramp up
            }
            if (playerInputs.right)
            {
                force = new Vector3(physicsVariables.runSpeed * groundAirRatio, force.y, force.z);//Hard set so there isnt any ramp up
            }

            //Add Gravity
            force += new Vector3(0.0f, physicsVariables.gravity, 0.0f);
            if (Mathf.Abs(force.x) < physicsVariables.airFriction)
                force.x = 0.0f;
            if (force.x != 0)
                force += new Vector3(-physicsVariables.airFriction * (force.x / Mathf.Abs(force.x)), 0.0f, 0.0f);

        }



        transform.Translate(force);
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Collider2D groundChecker = GetComponent<CircleCollider2D>();
            if (collision.otherCollider == groundChecker)
            {
                physicsVariables.grounded = true;
                Debug.Log("Collided with ground");
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Collider2D groundChecker = GetComponent<CircleCollider2D>();
            if (collision.otherCollider == groundChecker)
            {
                physicsVariables.grounded = false;
                Debug.Log("Left ground");
            }
        }
    }





}
