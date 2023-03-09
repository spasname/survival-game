using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace FirstPersonPlayer
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
        public Gravity gravity;

        float speedMultiplicator = 1f;
        float movementspeed;
        float horizontal;
        float vertical;

        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<CharacterController>();
            gravity = GetComponent<Gravity>();
        }

        // Update is called once per frame
        void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            jump();
        }

        private void FixedUpdate()
        {
            movePlayer();
        }

        private void movePlayer()
        {
            checkSprint();
            Vector3 moveHorizontal = transform.right * horizontal * 0.5f * movementspeed * speedMultiplicator;

            if (vertical < 0)
            {
                vertical /= 2;
            }
            Vector3 moveVertical = transform.forward * vertical * movementspeed * speedMultiplicator;
            controller.Move(moveHorizontal + moveVertical);
        }

        private void checkSprint()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementspeed = 0.25f;
            }
            else
            {
                movementspeed = 0.1f;
            }
        }

        private void jump()
        {
            if (gravity.isGrounded() && Input.GetKeyDown(KeyCode.Space))
            {
                gravity.setVelocity(0.2f);
            }
        }
    }
}
