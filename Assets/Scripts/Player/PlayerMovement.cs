using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private PlayerRotator rotator;
    
    private Rigidbody2D rb;

    private Vector2 moveInput;
    private Vector2 direction;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(x, y);

        if (moveInput != Vector2.zero)
            direction = moveInput;
        
        rotator.ApplyDirection(direction);
    }

    private void FixedUpdate()
    {
        Vector2 movement = moveInput.normalized * (movementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement);
    }

    public Vector2 Direction => direction;
}
