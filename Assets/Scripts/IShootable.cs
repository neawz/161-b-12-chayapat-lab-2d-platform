using UnityEngine;

public interface IShootable // Interface can't have Variable but can bypass by get; set;
{
    public GameObject Bullet {  get; set; }
    public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }
    public void Shoot();
}
