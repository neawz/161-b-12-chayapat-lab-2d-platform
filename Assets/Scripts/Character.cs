using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Stat
    private int health;
    public int Health
    {
        get { return health; }
        set { health = (value < 0) ? 0 : value; }
    }

    protected Animator anim;
    protected Rigidbody2D rb;

    public void Initialize(int startHealth)
    {
        Health = startHealth;
        rb = GetComponent<Rigidbody2D>();
        Debug.Log($"{this.name} initial Health: {this.Health}");
    }
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took {damage}. Health remain {Health}");
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
}
