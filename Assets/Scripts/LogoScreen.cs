using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScreen : MonoBehaviour
{
    [SerializeField] private float time, delay;
    [SerializeField] private GameObject logo;
    
    private void Start()
    {
        LeanTween.moveLocalX(logo, 0f, time)
            .setEaseOutBack()
            .setOnComplete(() => LeanTween.moveLocalX(logo, 2000f, time)
                .setEaseInBack()
                .setDelay(delay)
                .setOnComplete(() => SceneManager.LoadScene(1)));
    }
}
