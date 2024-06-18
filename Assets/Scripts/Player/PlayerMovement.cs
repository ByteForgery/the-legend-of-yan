using UnityEngine;

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

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        MoveInput = new Vector2(x, y);

        if (MoveInput != Vector2.zero)
            direction = MoveInput;
        
        rotator.ApplyDirection(direction);
    }

    private void FixedUpdate()
    {
        Vector2 movement = MoveInput.normalized * (movementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement);
    }

    public Vector2 Direction => direction;
}
