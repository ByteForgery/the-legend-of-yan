using UnityEngine;

public class UIMonoBehaviour : MonoBehaviour
{
    protected RectTransform RectTransform
    {
        get => (RectTransform)transform;
    }
}
