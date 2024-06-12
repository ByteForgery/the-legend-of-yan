using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlightAnimator : UIMonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float smoothInTime, smoothOutTime;
    [SerializeField] private float additionalSize;
    [SerializeField] private RectTransform highlightRect;

    private bool highlighted;

    private float velocity;

    private void Update()
    {
        float targetWidth = (highlighted ? additionalSize : 0f);
        float smoothTime = highlighted ? smoothInTime : smoothOutTime;

        Vector2 size = highlightRect.sizeDelta;
        size.x = Mathf.SmoothDamp(size.x, targetWidth, ref velocity, smoothTime);
        highlightRect.sizeDelta = size;
    }

    public void OnPointerEnter(PointerEventData eventData) => highlighted = true;

    public void OnPointerExit(PointerEventData eventData) => highlighted = false;
}
