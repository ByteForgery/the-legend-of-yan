using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField, InspectorName("Max Health")] private float _maxHealth;
    [SerializeField, InspectorName("Health")] private float _health;

    public float MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = Mathf.Max(value, 0f);
    }
    
    public float Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0f, _maxHealth);
    }

    public virtual void Damage(int damage)
    {
        if (damage < 0)
        {
            Debug.LogError("Damage cannot be negative!");
            return;
        }
        
        Health -= damage;
        if (Health == 0)
            OnDeath();
    }

    public virtual void Heal(int heal)
    {
        if (heal < 0)
        {
            Debug.LogError("Heal cannot be negative!");
            return;
        }

        Health += heal;
    }

    public void Kill()
    {
        Health = 0;
        OnDeath();
    }

    protected abstract void OnDeath();
    
    private void OnValidate()
    {
        _maxHealth = Mathf.Max(_maxHealth, 0f);
        _health = Mathf.Clamp(_health, 0f, _maxHealth);
    }
}
