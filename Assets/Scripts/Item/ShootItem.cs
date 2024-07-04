using UnityEngine;

[CreateAssetMenu(fileName = "New Wand Item", menuName = "Items/Wand")]
public class WandItem : Item
{
    [SerializeField] private GameObject projectilePrefab;
    
    public override void Use(Player player)
    {
        base.Use(player);

        Transform projectileSpawnspot = player.ProjectileSpawnspot;

        Vector2 direction = player.GetComponent<PlayerMovement>().Direction;
        
        Vector2 pos = (Vector2)projectileSpawnspot.position + direction;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rot = Quaternion.Euler(0f, 0f, angle);
        Instantiate(projectilePrefab, pos, rot);
    }
}
