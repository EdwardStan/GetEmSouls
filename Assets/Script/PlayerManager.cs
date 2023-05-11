using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SE
{
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputHandler;
        Animator anim;


        [Space]
        [Header("Player Flags")]
        public bool isInteracting;
        public bool isSprinting;
        public bool isInAir;
        public bool isGrounded;

        [Space]

        CameraHandler cameraHandler;
        PlayerLocomotion playerLocomotion;

        private void Awake()
        {
            cameraHandler = CameraHandler.instance;
        }

        // Start is called before the first frame update
        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            anim = GetComponentInChildren<Animator>();
            playerLocomotion= GetComponent<PlayerLocomotion>();
        }

        // Update is called once per frame
        void Update()
        {
            isInteracting = anim.GetBool("isInteracting");

            float delta = Time.deltaTime;

            inputHandler.TickInput(delta);

            playerLocomotion.HandleMovement(delta);
            playerLocomotion.HandleRollingAndSprint(delta);
            playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);
        }


        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;
            if (cameraHandler != null)
            {
                cameraHandler.FollowTarget(delta);
                cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
            }
        }

        private void LateUpdate()
        {
            inputHandler.rollFlag = false;
            inputHandler.sprintFlag = false;
            isSprinting = inputHandler.b_Input;

            if (isInAir)
            {
                playerLocomotion.inAirTImer = playerLocomotion.inAirTImer + Time.deltaTime;
            }
        }
    }

}

