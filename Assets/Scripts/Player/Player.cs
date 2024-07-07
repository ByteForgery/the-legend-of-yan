using UnityEngine;

public class Player : Actor
{
    [SerializeField] private int _maxMana;
    [SerializeField] private int _mana;
    [SerializeField] private HeartDisplay heartDisplay;
    [SerializeField] private ManaBarDisplay manaBarDisplay;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform projectileSpawnspot;
    [SerializeField] private DeathScreen deathScreen;

    public bool IsDead { get; private set; }

    public int MaxMana
    {
        get => _maxMana;
        set
        {
            if (value < 0) value = 0;
            _maxMana = value;
        }
    }

    public int Mana
    {
        get => _mana;
        set
        {
            if (value < 0) value = 0;
            if (value > _maxMana) value = _maxMana;
            _maxMana = value;
        }
    }

    private void Update()
    {
        heartDisplay.SetHealth(Health);
        manaBarDisplay.SetMana(Mana, MaxMana);
    }

    public void DrainMana(int mana)
    {
        if (mana < 0)
        {
            Debug.LogError("Mana to drain cannot be negative!");
            return;
        }

        Mana -= mana;
    }

    public void AddMana(int mana)
    {
        if (mana < 0)
        {
            Debug.LogError("Mana to add cannot be negative!");
            return;
        }

        Mana += mana;
    }

    protected override void OnDeath()
    {
        animator.Play("death");
        IsDead = true;

        GetComponent<PlayerInventory>().isToggled = false;
        
        deathScreen.Show();
    }
    
    private void OnValidate()
    {
        if (_maxMana < 0) _maxMana = 0;

        if (_mana < 0) _mana = 0;
        if (_mana > _maxMana) _mana = _maxMana;
    }

    public bool HasMana => Mana > 0;

    public Transform ProjectileSpawnspot => projectileSpawnspot;
}
