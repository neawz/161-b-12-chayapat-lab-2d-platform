using UnityEngine;

public class Crocodile : Enemy, IShootable
{
    [SerializeField] float attackRange;
    public Player player;

    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    void Start()
    {
        base.Initialize(60);
        DamageHit = 30;
        attackRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();
        WaitTime = 0.0f;
        ReloadTime = 5.0f;
    }
    void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
        Behaviour();
    }
    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot");
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Rock rock = GetComponent<Rock>();
            rock.InitWeapon(30, this);
            WaitTime = 0.0f; // Reset Timer
        }
    }
    public override void Behaviour()
    {
        // Find distance between Croco and Player
        Vector2 distance = transform.position - player.transform.position;
        if (distance.magnitude <= attackRange)
        {
            Debug.Log($"{player.name} is in the {this.name}'s Range!");
            Shoot();
        }
    }
}
