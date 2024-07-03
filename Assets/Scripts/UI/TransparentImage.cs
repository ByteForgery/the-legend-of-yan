using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TransparentImage : MonoBehaviour
{
    private Image image;
    
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        Color color = image.color;
        color.a = image.sprite == null ? 0f : 1f;
        image.color = color;
    }
}