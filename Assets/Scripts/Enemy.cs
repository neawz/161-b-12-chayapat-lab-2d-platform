using UnityEngine;

public abstract class Enemy : Character
{
    private int damageHit;
    public int DamageHit
    {
        get { return damageHit; }
        set { damageHit = value; }
    }
    public abstract void Behaviour();
}
