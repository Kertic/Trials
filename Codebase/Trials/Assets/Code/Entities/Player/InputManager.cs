using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Entities.Player
{
    public enum InputTypes
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        ATTACK,
        SKILL1,
        SKILL2,
        SKILL3,
        NUM_OF_INPUT_TYPES
    }
    public delegate void PlayerInput(InputTypes inputType, bool wasPress);
    public class InputManager : MonoBehaviour
    {
        public PlayerInput p1InputDelegate;
        public PlayerInput p2InputDelegate;
        public PlayerInput p3InputDelegate;
        public PlayerInput p4InputDelegate;

        private bool[,] _isCurrentlyPressed;
        // Use this for initialization
        private void Start()
        {
            _isCurrentlyPressed = new bool[4, (int)InputTypes.NUM_OF_INPUT_TYPES];
        }

        // Update is called once per frame
        void Update()
        {

            //Decide to call delegates or not
            for (int player = 0; player < 4; player++)
                for (int inputType = 0; inputType < (int)InputTypes.NUM_OF_INPUT_TYPES; inputType++)
                    ButtonMessageFactory((InputTypes)inputType, player);

        }

        void ButtonMessageFactory(InputTypes inputType, int playerIndex)
        {
            bool isInputDown = false;

            switch (inputType)
            {
                #region Up Input
                case InputTypes.UP:
                    switch (playerIndex)
                    {
                        case 0:
                            isInputDown = Input.GetAxis("VerticalP1") > 0.0f;
                            break;
                        case 1:
                            isInputDown = Input.GetAxis("VerticalP2") > 0.0f;
                            break;
                        case 2:
                            isInputDown = Input.GetAxis("VerticalP3") > 0.0f;
                            break;
                        case 3:
                            isInputDown = Input.GetAxis("VerticalP4") > 0.0f;
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                #region Down Input
                case InputTypes.DOWN:
                    switch (playerIndex)
                    {
                        case 0:
                            isInputDown = Input.GetAxis("VerticalP1") < 0.0f;
                            break;
                        case 1:
                            isInputDown = Input.GetAxis("VerticalP2") < 0.0f;
                            break;
                        case 2:
                            isInputDown = Input.GetAxis("VerticalP3") < 0.0f;
                            break;
                        case 3:
                            isInputDown = Input.GetAxis("VerticalP4") < 0.0f;
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                #region Left Input
                case InputTypes.LEFT:
                    switch (playerIndex)
                    {
                        case 0:
                            isInputDown = Input.GetAxis("HorizontalP1") < 0.0f;
                            break;
                        case 1:
                            isInputDown = Input.GetAxis("HorizontalP2") < 0.0f;
                            break;
                        case 2:
                            isInputDown = Input.GetAxis("HorizontalP3") < 0.0f;
                            break;
                        case 3:
                            isInputDown = Input.GetAxis("HorizontalP4") < 0.0f;
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                #region Right Input
                case InputTypes.RIGHT:
                    switch (playerIndex)
                    {
                        case 0:
                            isInputDown = Input.GetAxis("HorizontalP1") > 0.0f;
                            break;
                        case 1:
                            isInputDown = Input.GetAxis("HorizontalP2") > 0.0f;
                            break;
                        case 2:
                            isInputDown = Input.GetAxis("HorizontalP3") > 0.0f;
                            break;
                        case 3:
                            isInputDown = Input.GetAxis("HorizontalP4") > 0.0f;
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                #region Attack Input
                case InputTypes.ATTACK:
                    switch (playerIndex)
                    {
                        case 0:
                            isInputDown = Input.GetAxis("AttackP1") > 0.0f;
                            break;
                        case 1:
                            isInputDown = Input.GetAxis("AttackP2") > 0.0f;
                            break;
                        case 2:
                            isInputDown = Input.GetAxis("AttackP3") > 0.0f;
                            break;
                        case 3:
                            isInputDown = Input.GetAxis("AttackP4") > 0.0f;
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                #region Skill 1 input
                case InputTypes.SKILL1:
                    switch (playerIndex)
                    {
                        case 0:
                            isInputDown = Input.GetAxis("Skill1P1") > 0.0f;
                            break;
                        case 1:
                            isInputDown = Input.GetAxis("Skill1P2") > 0.0f;
                            break;
                        case 2:
                            isInputDown = Input.GetAxis("Skill1P3") > 0.0f;
                            break;
                        case 3:
                            isInputDown = Input.GetAxis("Skill1P4") > 0.0f;
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                #region Skill 2 Input
                case InputTypes.SKILL2:
                    switch (playerIndex)
                    {
                        case 0:
                            isInputDown = Input.GetAxis("Skill2P1") > 0.0f;
                            break;
                        case 1:
                            isInputDown = Input.GetAxis("Skill2P2") > 0.0f;
                            break;
                        case 2:
                            isInputDown = Input.GetAxis("Skill2P3") > 0.0f;
                            break;
                        case 3:
                            isInputDown = Input.GetAxis("Skill2P4") > 0.0f;
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                #region Skill 3 Input
                case InputTypes.SKILL3:
                    switch (playerIndex)
                    {
                        case 0:
                            isInputDown = Input.GetAxis("Skill3P1") > 0.0f;
                            break;
                        case 1:
                            isInputDown = Input.GetAxis("Skill3P2") > 0.0f;
                            break;
                        case 2:
                            isInputDown = Input.GetAxis("Skill3P3") > 0.0f;
                            break;
                        case 3:
                            isInputDown = Input.GetAxis("Skill3P4") > 0.0f;
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                default:
                    break;
            }

            if (isInputDown)
            {
                if (!GetIsCurrentlyPressed(playerIndex, inputType))//if its not currently pressed, send the "Press" message
                    switch (playerIndex)
                    {
                        case 0:
                            if (p1InputDelegate != null)
                                p1InputDelegate(inputType, true);
                            break;
                        case 1:
                            if (p2InputDelegate != null)
                                p2InputDelegate(inputType, true);
                            break;
                        case 2:
                            if (p3InputDelegate != null)
                                p3InputDelegate(inputType, true);
                            break;
                        case 3:
                            if (p4InputDelegate != null)
                                p4InputDelegate(inputType, true);
                            break;
                        default:
                            break;
                    }


                SetIsCurrentlyPressed(playerIndex, inputType, true);
            }
            else
            {
                if (GetIsCurrentlyPressed(playerIndex, inputType))//If it was pressed, but now its not (due to the else) then we need to send the release message
                    switch (playerIndex)
                    {
                        case 0:
                            p1InputDelegate(inputType, false);
                            break;
                        case 1:
                            p2InputDelegate(inputType, false);
                            break;
                        case 2:
                            p3InputDelegate(inputType, false);
                            break;
                        case 3:
                            p4InputDelegate(inputType, false);
                            break;
                        default:
                            break;
                    }

                SetIsCurrentlyPressed(playerIndex, inputType, false);
            }
        }

        void SetIsCurrentlyPressed(int playerIndex, InputTypes inputType, bool isPressed)
        {
            _isCurrentlyPressed[playerIndex, (int)inputType] = isPressed;
        }
        public bool GetIsCurrentlyPressed(int playerIndex, InputTypes inputType)
        {
            return _isCurrentlyPressed[playerIndex, (int)inputType];
        }
    }
}