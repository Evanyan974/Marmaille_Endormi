using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputSystem controls;
    private Rigidbody rb;
    private Vector3 moveInput; //raw input receptionné depuis la manette
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float newSpeed;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField] private bool isGround;

    [SerializeField] private float acceleration;
    [SerializeField] private float decceleration;
    [SerializeField] private float velocityPower;

    public InputSystem Controls { get => controls; set => controls = value; }
    public Rigidbody Rb { get => rb; set => rb = value; }
    public Vector3 MoveInput { get => moveInput; set => moveInput = value; }
    public float Speed { get => speed; set => speed = value; }
    public float NewSpeed { get => newSpeed; set => newSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }

    private void Awake()
    {
        Controls = new InputSystem();

        Rb = GetComponent<Rigidbody>();

        NewSpeed = Speed = speed;
        JumpForce = jumpForce;
    }


    private void OnEnable()
    {
        // Inscrit le move
        Controls.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector3>();
        Controls.Player.Move.canceled += ctx => MoveInput = Vector3.zero;

        Controls.Player.Jump.performed += ctx => Jump();

        // Enable l'InputAction
        controls.Enable();
    }


    private void OnDisable()
    {
        controls.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        //transform.Translate(MoveInput.x * NewSpeed * Time.deltaTime, 0, MoveInput.z * NewSpeed * Time.deltaTime);

        MovementNoByMe();
    }

    void Jump()
    {
        if (isGround)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }


    /// <summary>
    /// Smoother Movement By Dawnosaur
    /// </summary>
    void MovementNoByMe()
    {

        float targetSpeed = moveInput.x * speed; // explicit
        float speedDif = targetSpeed - rb.velocity.x; // drag ? 
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration; // explicit
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velocityPower) * Mathf.Sign(speedDif); // application with direction by Math.Sign

        /*if (!canMove) // NO MOVE !
        {
            movement = 0; // Moven't
        }*/

        rb.AddForce(movement * Vector2.right); // Player move !
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
