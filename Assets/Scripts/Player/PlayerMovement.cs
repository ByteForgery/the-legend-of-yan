using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private PlayerRotator rotator;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer gfx;
    
    private Rigidbody2D rb;

    private Vector2 moveInput;
    public Vector2 Direction { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = moveInput.normalized * (movementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();

        if (IsMoving)
        {
            Direction = moveInput;
            animator.SetBool("IsMoving", true);
        } else
            animator.SetBool("IsMoving", false);

        rotator.ApplyDirection(Direction);

        if (Direction.x != 0f)
            gfx.flipX = Direction.x < 0f;
    }

    public bool IsMoving => moveInput != Vector2.zero;
}
