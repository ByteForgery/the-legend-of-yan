using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryCell : MonoBehaviour
{
    [HideInInspector] public bool selected;

    [SerializeField] private Item item;
    [SerializeField] private Image iconImage;
    [SerializeField] private GameObject outline;

    private void Update()
    {
        if (item == null) return;
            
        iconImage.sprite = item.Sprite;
        
        outline.SetActive(selected);
    }

    public Item Item => item;
}
