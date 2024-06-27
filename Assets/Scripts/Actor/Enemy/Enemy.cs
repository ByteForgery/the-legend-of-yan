using UnityEngine;

public class Enemy : Actor
{
    protected override void OnDeath()
    {
        Destroy(gameObject);
    }
}
