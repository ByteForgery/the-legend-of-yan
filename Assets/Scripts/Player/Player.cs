public class Player : Actor
{
    public void OnDeathAnimFinished()
    {
        Destroy(gameObject);
    }

    protected override void OnDeath()
    {
        
    }
}
