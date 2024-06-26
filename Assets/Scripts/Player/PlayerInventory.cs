using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Item item;

    private bool isShowing;
    
    private void Update()
    {
        if (item != null && Input.GetKeyDown(KeyCode.E))
            item.Use(transform);
    }

    public void Toggle()
    {
        isShowing = !isShowing;
        
        
    }
}
