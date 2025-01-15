using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;

    [Header("Movement")]
    [SerializeField] private float jumpPower = 10f;
    public float walkSpeed = 5f;

    [Header("Drag")]
    private float gravity = -9.81f;
    private float verticalVelocity;

    [Header("Player Settings")]
    [SerializeField] private float gravityMultiplier = 3.0f;
    [SerializeField] private int points = 500;
    public float playerHealth = 100f;


    private CharacterController characterController;
    private GameManager gameManager;
    private Vector3 moveDirection;
    private Vector2 inputMovement;
    private float horizontalInput;
    private float verticalInput;
    private bool isDoublePointsActive;
    public static PlayerController Instance;


    private void Awake()
    {
        Instance = this;
        characterController = GetComponent<CharacterController>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        HandleGravity();
        HandleMovement();
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

    private void HandleMovement()
    {
        Vector3 move = orientation.forward * inputMovement.y + orientation.right * inputMovement.x;
        characterController.Move(move * walkSpeed * Time.deltaTime + moveDirection * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && IsGrounded())
        {
            verticalVelocity = jumpPower;
        }
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