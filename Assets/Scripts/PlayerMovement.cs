using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxVelocity;

    private Rigidbody2D rb;
    private IInputHandler inputHandler;
    private Vector2 initialPosition;
    private Vector2 initialVelocity;
    private Quaternion initialRotation;
    private bool allowMovementAndRotation;

    [Inject]
    private void Construct(IInputHandler inputHandler) => this.inputHandler = inputHandler;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Start()
    {
        AllowMovementAndRotation();

        initialPosition = transform.position;
        initialVelocity = rb.velocity;
        initialRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        if (!allowMovementAndRotation) return;

        Move();
        Rotate();
    }

    public void AllowMovementAndRotation() => allowMovementAndRotation = true;

    public void StopMovementAndRotation() => allowMovementAndRotation = false;

    private void Move()
    {
        rb.velocity += inputHandler.Vertical * movementSpeed * Time.fixedDeltaTime * (Vector2)(transform.up);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }

    private void Rotate()
    {
        rb.MoveRotation(rb.rotation + (-inputHandler.Horizontal * rotationSpeed * Time.fixedDeltaTime));
    }

    public void ResetPositionAndRotation()
    {
        transform.position = initialPosition;
        rb.velocity = initialVelocity;
        transform.rotation = initialRotation;
    }
}
