using System.Collections;
using System.Collections.Generic;
using Code.Entities.Player;
using Code.GameManager;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private InputManager _inputManager;
    private Player _ourPlayer;


    #region Physics variables

    private Vector3 _force; //Move by this much each frame 

    [System.Serializable]
    public class SPhysicsVariables
    {
        public bool grounded = false;
        public float groundFriction = 0.1f;
        public float airFriction = 0.1f;
        public float runSpeed = 0.4f;
        public float jumpHeight = 1.0f;
        public float gravity = -0.049f;
        public float maxFallSpeed = -0.1f;
    }

    [SerializeField] SPhysicsVariables physicsVariables;
    [SerializeField] float physScaler;

    #endregion

    // Use this for initialization
    void Start()
    {
        _inputManager = FindObjectOfType<GameManager>().GetComponent<InputManager>();
        _ourPlayer = GetComponent<Player>();

        #region Input Delegate Assignment

        switch (_ourPlayer.playerIndex)
        {
            case 0:
                _inputManager.p1InputDelegate += InputResponse;
                break;
            case 1:
                _inputManager.p2InputDelegate += InputResponse;
                break;
            case 2:
                _inputManager.p3InputDelegate += InputResponse;
                break;
            case 3:
                _inputManager.p4InputDelegate += InputResponse;
                break;
            default:
                break;
        }

        #endregion


        _force = new Vector3(0.0f, 0.0f, 0.0f);

        #region Initialize Physics Variables

        physicsVariables.grounded = false;
        physicsVariables.groundFriction = 0.1f * physScaler; //0.1f
        physicsVariables.airFriction = 0.1f * physScaler; //0.1f
        physicsVariables.runSpeed = 0.4f * physScaler; //0.4f
        physicsVariables.jumpHeight = 1.0f * physScaler; //1.0f
        physicsVariables.gravity = -0.049f * (physScaler * 0.25f); //-0.049f
        physicsVariables.maxFallSpeed = -0.1f * physScaler; //maxFallSpeed

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
    }

    void InputResponse(InputTypes inputType, bool wasPress)
    {
        switch (inputType)
        {
            case InputTypes.UP:
                if (wasPress)
                    _force += new Vector3(0.0f, physicsVariables.jumpHeight, 0.0f);
                break;
            case InputTypes.DOWN:
                break;
            case InputTypes.LEFT:
                break;
            case InputTypes.RIGHT:
                break;
            case InputTypes.ATTACK:
                break;
            case InputTypes.SKILL1:
                break;
            case InputTypes.SKILL2:
                break;
            case InputTypes.SKILL3:
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        if (physicsVariables.grounded)
        {
            if (_inputManager.GetIsCurrentlyPressed(_ourPlayer.playerIndex, InputTypes.LEFT))
            {
                _force = new Vector3(-physicsVariables.runSpeed, _force.y,
                                     _force.z); //Hard set so there isnt any ramp up
            }

            if (_inputManager.GetIsCurrentlyPressed(_ourPlayer.playerIndex, InputTypes.RIGHT))
            {
                _force = new Vector3(physicsVariables.runSpeed, _force.y,
                                     _force.z); //Hard set so there isnt any ramp up
            }


            if (Mathf.Abs(_force.x) < physicsVariables.groundFriction)
                _force.x = 0.0f;

            if (_force.x != 0)
                _force += new Vector3(-physicsVariables.groundFriction * (_force.x / Mathf.Abs(_force.x)), 0.0f, 0.0f);
        }
        else //Not grounded
        {
            float groundAirRatio = physicsVariables.groundFriction / physicsVariables.airFriction;
            if (_inputManager.GetIsCurrentlyPressed(_ourPlayer.playerIndex, InputTypes.LEFT))
            {
                _force = new Vector3(-physicsVariables.runSpeed * groundAirRatio, _force.y,
                                     _force.z); //Hard set so there isnt any ramp up
            }

            if (_inputManager.GetIsCurrentlyPressed(_ourPlayer.playerIndex, InputTypes.RIGHT))
            {
                _force = new Vector3(physicsVariables.runSpeed * groundAirRatio, _force.y,
                                     _force.z); //Hard set so there isnt any ramp up
            }

            //Add Gravity
            _force += new Vector3(0.0f, physicsVariables.gravity, 0.0f);
            if (Mathf.Abs(_force.x) < physicsVariables.airFriction)
                _force.x = 0.0f;
            if (_force.x != 0)
                _force += new Vector3(-physicsVariables.airFriction * (_force.x / Mathf.Abs(_force.x)), 0.0f, 0.0f);
        }


        transform.Translate(_force);
        GameManager.PlayerMoveDelegate(_ourPlayer.playerIndex);
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Collider2D groundChecker = GetComponent<CircleCollider2D>();
            if (collision.otherCollider == groundChecker)
            {
                physicsVariables.grounded = true;
                _force.y = 0.0f;
                Debug.Log("Collided with ground");
                float deltaMidpoints = 0.5f * GetComponent<SpriteRenderer>().bounds.size.y +
                                       (0.5f * collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.y);
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
        if (collision.gameObject.CompareTag("Ground"))
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