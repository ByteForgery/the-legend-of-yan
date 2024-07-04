using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Nico
[RequireComponent(typeof(Rigidbody2D))]
public class DroppedPotionItem : MonoBehaviour
{
    [SerializeField] private float minForceX, maxForceX, forceY;
    [SerializeField] private List<HealItem> potions = new List<HealItem>();
    [SerializeField] private SpriteRenderer gfx;

    private Rigidbody2D rb;

    private HealItem potion;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        potion = potions[Random.Range(0, potions.Count - 1)];

        gfx.sprite = potion.Sprite;
    }

    private void Start()
    {
        float forceX = Random.Range(minForceX, maxForceX);
        Vector2 force = new Vector2(forceX, forceY);
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void Pickup()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject other = col.gameObject;
        if (!other.CompareTag("Player"))
        {

            Destroy(other);

            rb.gravityScale = 0f;
            rb.totalForce = Vector2.zero;
        }
    }

    public HealItem Potion => potion;
}
