using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputSystem controls;
    private Rigidbody2D rb;
    private Vector3 moveInput; //raw input receptionné depuis la manette
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float newSpeed;
    [SerializeField]
    private float jumpForce = 5f;

    public InputSystem Controls { get => controls; set => controls = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }
    public Vector3 MoveInput { get => moveInput; set => moveInput = value; }
    public float Speed { get => speed; set => speed = value; }
    public float NewSpeed { get => newSpeed; set => newSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }

    private void Awake()
    {
        Controls = new InputSystem();

        Rb = GetComponent<Rigidbody2D>();

        NewSpeed = Speed = speed;
        JumpForce = jumpForce;
    }


    private void OnEnable()
    {
        // Inscrit le move
        Controls.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector3>();
        Controls.Player.Move.canceled += ctx => MoveInput = Vector3.zero;

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
        transform.Translate(MoveInput.x * NewSpeed * Time.deltaTime, 0, MoveInput.z * NewSpeed * Time.deltaTime);
    }
}
