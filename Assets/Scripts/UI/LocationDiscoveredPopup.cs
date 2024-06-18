using System.Collections;
using TMPro;
using UnityEngine;

public class LocationDiscoveredPopup : UIMonoBehaviour
{
    [SerializeField] private float alphaInTime, alphaOutTime;
    [SerializeField] private float stayTime;
    [SerializeField] private float underlineGrowTime;
    [SerializeField] private float underlinePadding;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text locationText;
    [SerializeField] private RectTransform underlineSpace;
    [SerializeField] private RectTransform underline;
    [SerializeField] private CanvasGroup group;

    public void Show(string name, string location)
    {
        nameText.text = name;
        locationText.text = location;

        StartCoroutine(ShowCo());
    }

    private IEnumerator ShowCo()
    {
        yield return new WaitForEndOfFrame();
        
        RectTransform nameTrans = nameText.rectTransform;
        RectTransform locationTrans = locationText.rectTransform;
        
        Vector2 size = rectTransform.sizeDelta;
        size.x = nameTrans.rect.width;
        rectTransform.sizeDelta = size;

        float newUnderlineX = -locationTrans.rect.width - underlinePadding;
        underlineSpace.anchoredPosition = new Vector2(newUnderlineX, underlineSpace.anchoredPosition.y);

        float underlineWidth = nameTrans.rect.width - locationTrans.rect.width - underlinePadding;
        underlineSpace.sizeDelta = new Vector2(underlineWidth, underlineSpace.sizeDelta.y);

        underline.LeanSize(new Vector2(underlineWidth, underline.sizeDelta.y), underlineGrowTime)
            .setEaseInOutSine();            
            
        group.LeanAlpha(1f, alphaInTime).setOnComplete(() =>
        {
            LeanTween.delayedCall(stayTime + underlineGrowTime, () =>
            {
                group.LeanAlpha(0f, alphaOutTime).setOnComplete(ResetUnderline);
            });
        });
    }

    private void ResetUnderline()
    {
        underline.sizeDelta = new Vector2(0f, underline.sizeDelta.y);
    }
}
