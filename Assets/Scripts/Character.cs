using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Stat
    [SerializeField] protected int maxHealth;
    private int health;
    public int Health
    {
        get { return health; }
        set { health = (value < 0) ? 0 : value; }
    }
    [SerializeField] protected HealthBarUI healthBar;
    [SerializeField] private GameObject healthBarPrefab;

    protected Animator anim;
    protected Rigidbody2D rb;

    public void Initialize(int startHealth)
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Health = startHealth;
        maxHealth = Health;

        Debug.Log($"{this.name} initial Health: {this.Health}");
    }
    
    public void TakeDamage(int damage)
    {
        Health -= Mathf.Clamp(damage, 0, maxHealth);
        Debug.Log($"{this.name} took {damage}. Health remain {Health}");
        UpdateHealthBar();
        IsDead();
    }
    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else return false;
    }
    public void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.SetHealth(Health, maxHealth);
        }
    }
}
