using UnityEngine;

[CreateAssetMenu(fileName = "New Wand Item", menuName = "Items/Wand")]
public class WandItem : Item
{
    [SerializeField] private GameObject projectilePrefab;

    public GameObject ProjectilePrefab => projectilePrefab;
}
