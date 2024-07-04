using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private float smoothTime;
    [SerializeField] private RectTransform inventoryRoot;
    [SerializeField] private RectTransform itemGrid;
    [SerializeField] private Image selectedItemDisplay;

    private float itemCooldown;

    public bool IsToggled { get; private set; }
    private float smoothVelocity;

    private int selectedCellIndex;
    private PlayerInventoryCell[] inventoryCells;

    private void Awake()
    {
        inventoryCells = itemGrid.GetComponentsInChildren<PlayerInventoryCell>();
    }

    private void Update()
    {
        Animate();
        MoveSelection();

        itemCooldown = Mathf.Max(0f, itemCooldown - Time.deltaTime);

        foreach (PlayerInventoryCell cell in inventoryCells)
            cell.selected = false;

        inventoryCells[selectedCellIndex].selected = true;

        selectedItemDisplay.sprite = SelectedItem.Sprite;
    }

    private void MoveSelection()
    {
        if (!IsToggled) return;

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
        float targetY = IsToggled ? 0f : 1100f;

        Vector2 pos = inventoryRoot.anchoredPosition;
        pos.y = Mathf.SmoothDamp(pos.y, targetY, ref smoothVelocity, smoothTime);
        inventoryRoot.anchoredPosition = pos;
    }

    public void UseItem(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || itemCooldown > 0f) return;
        
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

    public void ToggleInventory(InputAction.CallbackContext _) => IsToggled = !IsToggled;

    private PlayerInventoryCell SelectedCell => inventoryCells[selectedCellIndex];
    private Item SelectedItem => SelectedCell.item;
    private PlayerInventoryCell PotionCell => inventoryCells.Last();
}