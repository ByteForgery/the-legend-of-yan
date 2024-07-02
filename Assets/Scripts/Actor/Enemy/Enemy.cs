public abstract class Enemy : Actor
{
    protected override void OnDeath()
    {
        Destroy(gameObject);
    }
}
