using UnityEngine;

public class CreditsScreen : UIMonoBehaviour
{
    private const float THANKS_STOP_Y = 1440f / 2f;
    
    [SerializeField] private float rollSpeed = 100f;
    [SerializeField] private float thanksStayTime = 2f;
    [SerializeField] private float transitionSmoothTime = 1f;
    [SerializeField] private RectTransform creditsRoot;
    [SerializeField] private RectTransform thanksRect;
    [SerializeField] private CanvasGroup creditsGroup;
    [SerializeField] private Camera cam;

    private float initialY;
    
    private bool show;
    private bool stopRoll = true;

    private float transitionVelocity;

    private void Start()
    {
        initialY = creditsRoot.anchoredPosition.y;
    }

    public void ShowCredits()
    {
        stopRoll = false;
        show = true;

        Vector2 pos = creditsRoot.anchoredPosition;
        pos.y = initialY;
        creditsRoot.anchoredPosition = pos;
    }

    private void Update()
    {
        if (!stopRoll)
        {
            Vector2 pos = creditsRoot.anchoredPosition;
            pos.y += rollSpeed * Time.deltaTime;
            creditsRoot.anchoredPosition = pos;
        }

        float targetAlpha = show ? 1f : 0f;
        creditsGroup.alpha = Mathf.SmoothDamp(creditsGroup.alpha, targetAlpha, ref transitionVelocity, transitionSmoothTime);

        if (show && Input.GetKeyDown(KeyCode.Escape))
            show = false;

        Debug.Log($"Thanks Y: {cam.ScreenToWorldPoint(thanksRect.position).y}");
        if (cam.ScreenToWorldPoint(thanksRect.position).y >= 0f && !stopRoll)
        {
            stopRoll = true;
            LeanTween.delayedCall(thanksStayTime, () => show = false);
        }

        creditsGroup.blocksRaycasts = show;
    }
}
