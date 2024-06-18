using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Item item;
    
    void Update()
    {
        if (item != null && Input.GetKeyDown(KeyCode.E))
            item.Use(transform);
    }
}
