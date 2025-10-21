using UnityEditor.Tilemaps;
using UnityEngine;

public class Ant : Enemy
{
    [SerializeField] Vector2 velocity;
    public Transform[] MovePoints;

    void Start()
    {
        base.Initialize(20);
        DamageHit = 20;
        velocity = new Vector2(-1.0f, 0.0f); // Start with left
    }
    void FixedUpdate()
    {
        Behaviour();
    }
    public override void Behaviour()
    {
        // Move from Current
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        // Move Left
        if (velocity.x < 0 && rb.position.x <= MovePoints[0].position.x)
        {
            Flip();
        }
        // Move Right
        if (velocity.x >= 0 && rb.position.x >= MovePoints[1].position.x)
        {
            Flip();
        }
    }
    public void Flip()
    {
        velocity.x *= -1; // Change Direction
        // Flip Prefab
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
