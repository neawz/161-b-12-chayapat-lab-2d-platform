using UnityEngine;

public class Crocodile : Enemy
{
    [SerializeField] float attackRange;
    public Player player;

    void Start()
    {
        base.Initialize(60);
        DamageHit = 30;
        attackRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();
    }
    void FixedUpdate()
    {
        Behaviour();
    }
    public void Shoot()
    {
        Debug.Log($"{this.name} shoots at the {player.name}!");
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
