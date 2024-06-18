using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private PlayerRotator rotator;
    
    private Rigidbody2D rb;

    public Vector2 MoveInput {get; private set;}
    private Vector2 direction;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Vector2 movement = MoveInput.normalized * (movementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();

        if (MoveInput != Vector2.zero)
            Direction = moveInput;
        
        rotator.ApplyDirection(Direction);
    }
}
