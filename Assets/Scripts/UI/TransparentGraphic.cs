using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class TransparentGraphic : MonoBehaviour
{
    private Graphic graphic;
    
    private void Awake()
    {
        graphic = GetComponent<Graphic>();
    }

    void Update()
    {
        Color color = graphic.color;
        color.a = graphic.mainTexture == null ? 0f : 1f;
        graphic.color = color;
    }
}
