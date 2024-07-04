using UnityEngine;

[CreateAssetMenu(fileName = "New Heal Item", menuName = "Items/Heal Item")]
public class HealItem : Item
{
    [SerializeField] private int heal;
    [SerializeField] private int mana;

    public override void Use(Player player)
    {
        player.Heal(heal);
        player.AddMana(mana);
    }
}
