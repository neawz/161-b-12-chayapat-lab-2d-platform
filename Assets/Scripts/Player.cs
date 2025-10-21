using Unity.Android.Types;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    void Start()
    {
        base.Initialize(100);
    }
    public void Shoot()
    {

    }
    public void Jump()
    {

    }
    public void OnHitWith(Enemy target)
    {
        TakeDamage(target.DamageHit);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log($"{this.name} Hit with {enemy.name}!");
            OnHitWith(enemy);
        }
    }
}
