using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : UIMonoBehaviour
{
    [SerializeField] private float camSmoothTime;
    [SerializeField] private Camera cam;
    [SerializeField] private CanvasGroup transitionOverlay;

    private readonly Dictionary<string, RectTransform> screens = new Dictionary<string, RectTransform>();
    
    private Vector2 targetCamPos;

    private Vector2 camVelocity;

    private void Start()
    {
        for (int i = 0; i < rectTransform.childCount; i++)
        {
            RectTransform screen = (RectTransform) rectTransform.GetChild(i);
            screens[screen.name] = screen;
        }
        
        LeanTween.delayedCall(0.5f, RunTransition);
    }

    private void Update()
    {
        cam.transform.position = Vector2.SmoothDamp(cam.transform.position, targetCamPos, ref camVelocity, camSmoothTime);
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

        targetCamPos = screen.position;
    }
}
