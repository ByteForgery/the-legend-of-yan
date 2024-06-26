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
    
    private bool isShowing;
    private bool stopRoll = true;

    private float transitionVelocity;

    private void Start()
    {
        initialY = creditsRoot.anchoredPosition.y;
    }

    public void ShowCredits()
    {
        stopRoll = false;
        isShowing = true;

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

        float targetAlpha = isShowing ? 1f : 0f;
        creditsGroup.alpha = Mathf.SmoothDamp(creditsGroup.alpha, targetAlpha, ref transitionVelocity, transitionSmoothTime);

        if (isShowing && Input.GetKeyDown(KeyCode.Escape))
            isShowing = false;

        Debug.Log($"Thanks Y: {cam.ScreenToWorldPoint(thanksRect.position).y}");
        if (cam.ScreenToWorldPoint(thanksRect.position).y >= 0f && !stopRoll)
        {
            stopRoll = true;
            LeanTween.delayedCall(thanksStayTime, () => isShowing = false);
        }

        creditsGroup.blocksRaycasts = isShowing;
    }
}
