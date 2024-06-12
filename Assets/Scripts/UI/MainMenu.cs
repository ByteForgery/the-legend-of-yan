using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : UIMonoBehaviour
{
    [SerializeField] private float transitionSmoothTime;
    [SerializeField] private RectTransform screensRoot;
    [SerializeField] private CanvasGroup transitionOverlay;

    private readonly Dictionary<string, RectTransform> screens = new Dictionary<string, RectTransform>();
    
    private Vector2 targetPos;

    private Vector2 transitionVelocity;

    private void Start()
    {
        for (int i = 0; i < screensRoot.childCount; i++)
        {
            RectTransform screen = (RectTransform) screensRoot.GetChild(i);
            screens[screen.name] = screen;
        }
        
        LeanTween.delayedCall(0.5f, RunTransition);
    }

    private void Update()
    {
        screensRoot.anchoredPosition = Vector2.SmoothDamp(screensRoot.anchoredPosition, targetPos, ref transitionVelocity, transitionSmoothTime);
    }

    private void RunTransition()
    {
        LeanTween.alphaCanvas(transitionOverlay, 0f, 1f)
            .setEaseInOutSine()
            .setOnComplete(() => transitionOverlay.gameObject.SetActive(false));
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene(2);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void SetMenuPosition(string name)
    {
        if (!screens.TryGetValue(name, out RectTransform screen))
        {
            Debug.LogError($"Screen with name {name} does not exist!");
            return;
        }

        targetPos = -screen.anchoredPosition;
    }
}
