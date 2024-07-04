using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private string description;
    [SerializeField] private Sprite sprite;
    [SerializeField] private float cooldown;
    [SerializeField] private int manaConsumption;

    public virtual void Use(Player player)
    {
        if (manaConsumption <= 0) return;
        
        player.DrainMana(manaConsumption);
    }

    public string DisplayName => displayName;
    public string Description => description;
    public Sprite Sprite => sprite;
    public float Cooldown => cooldown;
    public float ManaConsumption => manaConsumption;
}
