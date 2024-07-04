using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private PlayerRotator rotator;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer gfx;

    private Player player;
    private Rigidbody2D rb;

    private Vector2 moveInput;
    public Vector2 Direction { get; private set; }

    private bool isSprinting;
    
    private void Awake()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        if (inventory.isToggled) return;
        
        Vector2 movement = moveInput.normalized * (movementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        if (player.IsDead)
        {
            moveInput = Vector2.zero;
            Direction = Vector2.zero;
            return;
        }
        
        if (inventory.isToggled)
        {
            moveInput = Vector2.zero;
            Direction = Vector2.zero;
            animator.Play("idle");
            return;
        }
        
        moveInput = ctx.ReadValue<Vector2>();

        if (IsMoving)
        {
            Direction = moveInput;
            animator.Play("running");
        } else
            animator.Play("idle");

        rotator.ApplyDirection(Direction);

        if (Direction.x != 0f)
            gfx.flipX = Direction.x < 0f;
    }

    public bool IsMoving => moveInput != Vector2.zero;
}
