using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup transitionOverlay;

    private void Start()
    {
        RunTransition();
    }

    private void RunTransition() => LeanTween.alphaCanvas(transitionOverlay, 0f, 1f).setEaseInOutSine();

    public void OnClickPlay() => SceneManager.LoadScene(2);

    public void OnClickSettings()
    {
        
    }
    
    public void OnClickQuit() => Application.Quit();
}
