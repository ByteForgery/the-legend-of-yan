using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlightAnimator : UIMonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float smoothInTime, smoothOutTime;
    [SerializeField] private RectTransform highlightsRoot;

    private bool showing;

    private float velocity;

    private void Update()
    {
        float targetWidth = showing ? rectTransform.rect.width : 0f;
        float smoothTime = showing ? smoothInTime : smoothOutTime;

        Vector2 size = highlightsRoot.sizeDelta;
        size.x = Mathf.SmoothDamp(size.x, targetWidth, ref velocity, smoothTime);
        highlightsRoot.sizeDelta = size;
    }

    public void OnPointerEnter(PointerEventData eventData) => showing = true;

    public void OnPointerExit(PointerEventData eventData) => showing = false;
}
