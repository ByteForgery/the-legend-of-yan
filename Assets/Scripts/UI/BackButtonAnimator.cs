using UnityEngine;
using UnityEngine.EventSystems;

public class BackButtonAnimator : UIMonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float smoothInTime, smoothOutTime;
    [SerializeField] private RectTransform arrowMask, arrow;
    
    private bool showing;

    private float velocity;
    
    void Update()
    {
        float targetPos = showing ? 0f : arrowMask.rect.width;
        float smoothTime = showing ? smoothInTime : smoothOutTime;

        Vector2 pos = arrow.anchoredPosition;
        pos.x = Mathf.SmoothDamp(pos.x, targetPos, ref velocity, smoothTime);
        arrow.anchoredPosition = pos;
    }

    public void OnPointerEnter(PointerEventData eventData) => showing = true;
    public void OnPointerExit(PointerEventData eventData) => showing = false;
}
