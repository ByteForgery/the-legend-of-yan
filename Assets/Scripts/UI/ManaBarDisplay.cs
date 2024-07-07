using UnityEngine;
using UnityEngine.UI;

public class ManaBarDisplay : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    public void SetMana(int mana, int maxMana)
    {
        slider.maxValue = maxMana;
        slider.value = mana;
    }
}
