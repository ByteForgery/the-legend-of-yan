using UnityEngine;

public class UIMonoBehaviour : MonoBehaviour
{
    protected RectTransform rectTransform
    {
        get => (RectTransform)transform;
    }
}
