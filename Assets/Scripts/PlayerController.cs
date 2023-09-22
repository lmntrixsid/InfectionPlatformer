using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Vector2 move;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 1.0f;
    private float jumpHeight = 2.0f;
    public bool isRegenerating = false;
    public float regenRate = 0;
    public float gravityValue = -20.0f;
    private float momentumFactor = 1f;
    private float currentSpeed = 0f; // To track the current speed.

    public Health health;

    float healthValue = 1;

    // To make currentSpeed accessible to other scripts.
    public float CurrentSpeed
    {
        get { return currentSpeed; }
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        health.InitializeHealth();
    }

    public void onmove(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
    }

    public void StartRegeneratingHealth(float rate)
    {
        isRegenerating = true;
        regenRate = rate;
    }

    public void StopRegeneratingHealth()
    {
        isRegenerating = false;
        regenRate = 0;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -0.5f;
        }

        // Calculate the current speed based on the move direction.
        currentSpeed = move.magnitude * playerSpeed;

        Vector3 moveDirection = new Vector3(move.x, 0, move.y);
        moveDirection.Normalize(); // Normalize to ensure the magnitude is not greater than 1.

        // Increase speed based on how long the move direction is held.
        float speed = playerSpeed + (momentumFactor * move.magnitude);
        controller.Move(moveDirection * Time.deltaTime * speed);

        if (moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = moveDirection;
            health.health -= Time.deltaTime * healthValue;
            if (health.health <= 0)
            {
                SceneManager.LoadScene(0);
                return;
            }
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (isRegenerating)
        {
            Debug.Log("Regenerating Health");
            health.health = Mathf.Min(health.health + regenRate * Time.deltaTime, health.maxHealth);
        }
    }
}
