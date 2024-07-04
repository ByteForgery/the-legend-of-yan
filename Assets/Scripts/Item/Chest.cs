using UnityEngine;

// Nico
public class Chest : Interactable
{
    [SerializeField] private Sprite openedChestSprite;
    [SerializeField] private SpriteRenderer gfx;
    [SerializeField] private Transform itemSpawnspot;
    [SerializeField] private GameObject droppedPotionPrefab;

    public override void OnInteract(Player player)
    {
        gfx.sprite = openedChestSprite;

        Instantiate(droppedPotionPrefab, itemSpawnspot.position, Quaternion.identity);
    }
}

