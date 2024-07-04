using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryCell : MonoBehaviour
{
    public Item item;

    [HideInInspector] public bool selected;

    [SerializeField] private Image iconImage;
    [SerializeField] private GameObject outline;

    private void Update()
    {
        if (item == null)
        {
            iconImage.sprite = null;
            outline.SetActive(false);
            return;
        }
            
        iconImage.sprite = item.Sprite;
        
        outline.SetActive(selected);
    }

    public void Clear() => item = null;
}
