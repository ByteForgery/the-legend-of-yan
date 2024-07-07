using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public bool isToggled;
    
    [SerializeField] private float smoothTime;
    [SerializeField] private RectTransform inventoryRoot;
    [SerializeField] private RectTransform itemGrid;
    [SerializeField] private Image selectedItemDisplay;
    [SerializeField] private TMP_Text itemNameText, itemDescriptionText;

    private float itemCooldown;
    
    private float smoothVelocity;

    private int selectedCellIndex;
    private PlayerInventoryCell[] inventoryCells;

    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
        
        inventoryCells = itemGrid.GetComponentsInChildren<PlayerInventoryCell>();
    }

    private void Update()
    {
        if (player.IsDead) return;
        
        Animate();
        MoveSelection();

        itemCooldown = Mathf.Max(0f, itemCooldown - Time.deltaTime);

        foreach (PlayerInventoryCell cell in inventoryCells)
            cell.selected = false;

        inventoryCells[selectedCellIndex].selected = true;

        selectedItemDisplay.sprite = SelectedItem.Sprite;

        itemNameText.text = SelectedItem.DisplayName;
        itemDescriptionText.text = SelectedItem.Description;
    }

    private void MoveSelection()
    {
        if (!isToggled) return;

        int dir = 0;
        if (Input.GetKeyDown(KeyCode.A)) dir = -1;
        if (Input.GetKeyDown(KeyCode.D)) dir = 1;

        int newSelectedCellIndex = selectedCellIndex + dir;
        int inventoryCellsLength = inventoryCells.Length - (PotionCell.item == null ? 1 : 0);

        if (newSelectedCellIndex < 0) newSelectedCellIndex = 0;
        if (newSelectedCellIndex >= inventoryCellsLength) newSelectedCellIndex = inventoryCellsLength - 1;

        selectedCellIndex = newSelectedCellIndex;
    }

    private void Animate()
    {
        float targetY = isToggled ? 0f : 1100f;

        Vector2 pos = inventoryRoot.anchoredPosition;
        pos.y = Mathf.SmoothDamp(pos.y, targetY, ref smoothVelocity, smoothTime);
        inventoryRoot.anchoredPosition = pos;
    }

    public void UseItem(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || itemCooldown > 0f) return;

        Player player = GetComponent<Player>();
        
        SelectedItem.Use(GetComponent<Player>());
        itemCooldown = SelectedItem.Cooldown;

        if (selectedCellIndex == inventoryCells.Length - 1)
        {
            selectedCellIndex = 0;
            PotionCell.Clear();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Transform other = col.transform;
        DroppedPotionItem potionItem = other.GetComponent<DroppedPotionItem>();
        if (potionItem != null)
        {
            PotionCell.item = potionItem.Potion;
            potionItem.Pickup();
        }
    }

    public void ToggleInventory(InputAction.CallbackContext _)
    {
        if (player.IsDead) return;
        
        isToggled = !isToggled;
    }

    private PlayerInventoryCell SelectedCell => inventoryCells[selectedCellIndex];
    private Item SelectedItem => SelectedCell.item;
    private PlayerInventoryCell PotionCell => inventoryCells.Last();
}