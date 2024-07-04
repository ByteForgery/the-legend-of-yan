using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;

    public int MaxHealth
    {
        get => _maxHealth;
        set
        {
            if (value < 0) value = 0;
            _maxHealth = value;
        }
    }
    
    public int Health
    {
        get => _health;
        set
        {
            if (value < 0) value = 0;
            if (value > _maxHealth) value = _maxHealth;
            _health = value;
        }
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
        if (_maxHealth < 0) _maxHealth = 0;

        if (_health < 0) _health = 0;
        if (_health > _maxHealth) _health = _maxHealth;
    }
}
