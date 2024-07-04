using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] private Sprite fullHeart, halfHeart, emptyHeart;

    private Image[] hearts;
    
    private void Awake()
    {
        hearts = GetComponentsInChildren<Image>();
    }

    public void SetHealth(int health)
    {
        foreach (Image heartFill in hearts)
            heartFill.sprite = emptyHeart;

        bool isUneven = health % 2 != 0;
        int fullHearts = isUneven ? ((health - 1) / 2) : (health / 2);

        for (int i = 0; i < fullHearts; i++)
            hearts[i].sprite = fullHeart;

        if (!isUneven) return;

        hearts[fullHearts].sprite = halfHeart;
    }
}
