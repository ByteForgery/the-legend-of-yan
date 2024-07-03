using UnityEngine;

public class HealItem : Item
{
    [SerializeField] private int heal;

    public override void Use(Transform player)
    {
        player.GetComponent<Player>().Heal(heal);
    }
}
