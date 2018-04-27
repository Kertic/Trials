using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{


    SPlayerInputs playerInputs;

    
    #region Secondary Input Variables
    bool jumpWasPressed;
    #endregion


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
        public float maxFallSpeed;
    }
    SPhysicsVariables physicsVariables;
    [SerializeField]
    float physScaler;
    #endregion

    // Use this for initialization
    void Start()
    {




        jumpWasPressed = false;


        force = new Vector3(0.0f, 0.0f, 0.0f);
        #region Initialize Physics Variables
        physicsVariables.grounded = false;
        physicsVariables.groundFriction = 0.1f * physScaler;//at 0.02 timestep, 0.25f
        physicsVariables.airFriction = 0.1f * physScaler;//0.25f
        physicsVariables.runSpeed = 0.4f * physScaler;//1.0f
        physicsVariables.jumpHeight = 1.0f * physScaler;//1.0f
        physicsVariables.gravity = -0.049f * (physScaler * 0.25f);//-0.049f
        physicsVariables.maxFallSpeed = -0.1f * physScaler;
        #endregion
        #region Adjust Colliders based on math
        #region Circle Collider (Ground Checker)
        CircleCollider2D groundChecker = GetComponent<CircleCollider2D>();
        groundChecker.radius = 0.06f;
        groundChecker.offset = new Vector2(
            groundChecker.offset.x,
            -(GetComponent<SpriteRenderer>().size.y * 0.5f - groundChecker.radius)
            );
        #endregion
        #region Box Collider (Hitbox)
        BoxCollider2D playerHitbox = GetComponent<BoxCollider2D>();
        playerHitbox.size = GetComponent<SpriteRenderer>().size;
        playerHitbox.size = new Vector2(playerHitbox.size.x, playerHitbox.size.y - groundChecker.radius * 2.0f);
        playerHitbox.offset = new Vector2(0.0f, groundChecker.radius);
        #endregion
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        playerInputs = GameObject.FindGameObjectWithTag("GameManager").GetComponent<InputManager>().GetInputStatus();

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
                if (!jumpWasPressed)
                    force += new Vector3(0.0f, physicsVariables.jumpHeight, 0.0f);
                jumpWasPressed = true;
            }
            else
                jumpWasPressed = false;


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
                float deltaMidpoints = 0.5f * GetComponent<SpriteRenderer>().bounds.size.y + (0.5f * collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.y);
                float desiredHeight = collision.gameObject.transform.position.y + deltaMidpoints;
                transform.Translate(0.0f, desiredHeight - transform.position.y, 0.0f);

            }
            groundChecker = GetComponent<BoxCollider2D>();
            if (collision.otherCollider == groundChecker)
            {
                Physics2D.IgnoreCollision(groundChecker, collision.collider, true);
                Debug.Log("Collision ignored between player box and" + collision.gameObject.name);
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
