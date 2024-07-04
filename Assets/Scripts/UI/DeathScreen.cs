using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : UIMonoBehaviour
{
    [SerializeField] private float smoothTime = 1f;

    private bool hasCompleted;
    
    public void Show()
    {
        LeanTween.moveY(RectTransform, 0f, smoothTime)
            .setEaseOutBounce()
            .setOnComplete(() => hasCompleted = true);
    }

    private void Update()
    {
        if (!hasCompleted || !Input.GetKeyDown(KeyCode.Space)) return;

        SceneManager.LoadScene(2);
    }
}
