using Unity.Android.Types;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    void Start()
    {
        base.Initialize(100);
        ReloadTime = 1.0f;
        WaitTime = 0.0f;
    }
    void FixedUpdate() // Loop Every 0.02 Sec
    {
        WaitTime += Time.fixedDeltaTime;
    }
    void Update()
    {
        Shoot();
    }
    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
            {
                banana.InitWeapon(20, this);
            }
            WaitTime = 0.0f; // Reset Timer
        }
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
    public void Jump()
    {

    }
}
