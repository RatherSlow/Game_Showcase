using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class PlayerInputMovement : MonoBehaviour
{
    InputSystem_Actions inputActions;
    InputAction move, look, attack, dash;

    CharacterController characterController;
    public Transform cameraContainer;

    public float maxSpeed = 10f;
    public float mouseSensitivity = 0.2f;
    public float gravity = 20.0f;
    public float dashSpeed = 25f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;


    Vector3 moveDirection = Vector3.zero;
    float speed = 6f;
    public float lookUpClamp = -30f;
    public float lookDownClamp = 40f;
    float rotateYaw, rotatePitch;

    bool isDashing = false;
    float dashCooldownTimer = 0f;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();

        inputActions.Player.Move.Enable();
        inputActions.Player.Look.Enable();
        inputActions.Player.Attack.Enable();
        inputActions.Player.Dash.Enable();
    }

    void Update()
    {
        RotateAndLook();

        // Handle cooldown timer
        if (dashCooldownTimer > 0f)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (move.ReadValue<Vector2>() != Vector2.zero)
        {
            Debug.Log("Move: " + move.ReadValue<Vector2>());
        }
        if (look.ReadValue<Vector2>() != Vector2.zero)
        {
            Debug.Log("Look: " + look.ReadValue<Vector2>());
        }

        Locomotion();
    }

    private void OnEnable()
    {
        move = inputActions.Player.Move;
        move.Enable();

        look = inputActions.Player.Look;
        look.Enable();

        attack = inputActions.Player.Attack;
        attack.Enable();
        attack.performed += Attack;

        dash = inputActions.Player.Dash;
        dash.Enable();
        dash.performed += context => TryDash();
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
        attack.Disable();
        dash.Disable();
    }

    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack Button Pressed");
        
    }

    void Locomotion()
    {
        if (!isDashing) // When not dashing
        {
            // Get input and move
            Vector2 input = move.ReadValue<Vector2>();
            moveDirection = new Vector3(input.x, 0f, input.y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void RotateAndLook()
    {
        Vector2 lookInput = look.ReadValue<Vector2>();

        rotateYaw += lookInput.x * mouseSensitivity;
        rotatePitch -= lookInput.y * mouseSensitivity;
        rotatePitch = Mathf.Clamp(rotatePitch, lookUpClamp, lookDownClamp);

        cameraContainer.transform.localRotation = Quaternion.Euler(rotatePitch, rotateYaw, 0f);
    }

    void TryDash()
    {
        if (dashCooldownTimer <= 0f && !isDashing)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    IEnumerator DashCoroutine()
    {
        isDashing = true;
        dashCooldownTimer = dashCooldown;

        // Player is invincible while dashing
        // PlayerHealth health = GetComponent<PlayerHealth>();
        // health.isInvincible = true;

        Vector2 input = move.ReadValue<Vector2>();
        if (input == Vector2.zero)
            input = new Vector2(0, 1); // dash forward if no movement

        Vector3 dashDir = transform.TransformDirection(new Vector3(input.x, 0, input.y).normalized);

        float startTime = Time.time;
        while (Time.time < startTime + dashDuration)
        {
            characterController.Move(dashDir * dashSpeed * Time.deltaTime);
            yield return null;
        }

        //health.isInvincible = false;
        isDashing = false;
    }
}
