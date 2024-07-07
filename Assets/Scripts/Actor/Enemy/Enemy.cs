using UnityEngine;

public class Enemy : Actor
{
    [SerializeField] private float hitDelay = 1f;
    [SerializeField] private float chestChance = 0.07f;
    [SerializeField] private GameObject chestPrefab;
    private GameObject EnemySpawner;
    private EnemySpawner espawn;
    private float nextHitTime;

    void Start()
    {   EnemySpawner = GameObject.Find("Enemy Spawner");
        espawn = EnemySpawner.GetComponent<EnemySpawner>();
            if (espawn == null) {
            Debug.Log("Eyy das ist leer");
        }
    }
    protected override void OnDeath()
    {
        if (Random.value <= chestChance)
            Instantiate(chestPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        espawn.count = espawn.count + 1;
        espawn.SetLevel();
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (nextHitTime > Time.time) return;
        nextHitTime = Time.time + hitDelay;
        
        Transform other = col.transform;
        if (!other.CompareTag("Player")) return;

        Player player = other.GetComponent<Player>();
        player.Damage(1);
    }
}
