using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private string description;
    [SerializeField] private Sprite sprite;
    [SerializeField] private float cooldown;

    public virtual void Use(Transform player)
    {
        Debug.Log($"Using {displayName}");
    }

    public string DisplayName => displayName;
    public string Description => description;
    public Sprite Sprite => sprite;
    public float Cooldown => cooldown;
}
