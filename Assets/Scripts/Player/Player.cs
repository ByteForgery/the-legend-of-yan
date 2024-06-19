using UnityEngine;

public class Player : MonoBehaviour
{
    public void OnDeathAnimFinished()
    {
        Destroy(gameObject);
    }
}
