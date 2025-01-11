using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
public class PlayerController : MonoBehaviour {

    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform orientation;
    
    [Header("Movement")]
    [SerializeField] private float jumpPower = 10f;
    [SerializeField] private float walkSpeed = 5f;

    [Header("Drag")]
    [SerializeField] private float drag = 6f;

    [Header("Player Settings")]
    [SerializeField] private float gravityMultiplier = 3.0f;
    [SerializeField] private float playerHealth = 100f;
    [SerializeField] private int points = 500;
    
    private CharacterController characterController;
    private GameManager gameManager;

    private Vector3 moveDirection;
    private Vector2 input;
    private float horizontalInput;
    private float verticalInput;

    private bool isDoublePointsActive;
    private float gravity = -9.81f;
    private float verticalVelocity;


    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        HandleGravity();
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 move = transform.right * input.x + transform.forward * input.y;
        characterController.Move(move * walkSpeed * Time.deltaTime + moveDirection * Time.deltaTime);
    }

    private void HandleGravity()
    {
        if (IsGrounded() && verticalVelocity < 0)
        {
            verticalVelocity = -1f;
        }
        else
        {
            verticalVelocity += gravity * gravityMultiplier * Time.deltaTime;
        }
        moveDirection.y = verticalVelocity;  
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && IsGrounded())
        {
            verticalVelocity = jumpPower;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }


    private bool IsGrounded() => characterController.isGrounded;


    public void ActivatePowerup(int id, float duration, GameObject powerup)
    {
        if (id == 0)
        {
            if (!isDoublePointsActive)
            {
                ActivateDoublePoints(duration);
                Destroy(powerup);
            }
        }
        else if (id == 1)
        {
            BonusPoints();
            Destroy(powerup);
            Debug.Log("bonus points opgepakt");
        }
    }

    private void ActivateDoublePoints(float duration)
    {
        Debug.Log("double points active");
        isDoublePointsActive = true;
        gameManager.scoreMultiplier = 2f;
        StartCoroutine(DoublePointsCooldown(duration));
    }

    IEnumerator DoublePointsCooldown(float duration)
    {
        yield return new WaitForSeconds(duration);
        isDoublePointsActive = false;
        gameManager.scoreMultiplier = 1f;
        Debug.Log("double points uitgezet");
    }

    private void BonusPoints()
    {
        gameManager.AddScore(500);
    }
}