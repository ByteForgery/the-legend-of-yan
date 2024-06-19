using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WandProjectile : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private int damage;
    [SerializeField] private float range;

    private Vector2 initialPos;

    private void Start()
    {
        initialPos = transform.position;
        
        GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Vector2.Distance(initialPos, transform.position) >= range)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D otherCol)
    {
        Debug.Log("COLLISION");
        
        Transform other = otherCol.transform;

        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
            enemy.Damage(damage);
        
        Destroy(gameObject);
    }
}
