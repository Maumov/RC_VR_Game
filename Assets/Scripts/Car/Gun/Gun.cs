using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    private Transform startingPoint;
    [SerializeField]
    private Projectile projectile;
    public float secondsBetweenShoots = 1;
    [SerializeField]
    private float projectileSpeed = 35;

    private float nextShootTime;
    public void Shoot()
    {
        if(Time.time > nextShootTime)
        {
            nextShootTime = Time.time + secondsBetweenShoots;
            Projectile newProjectile = Instantiate(projectile, startingPoint.position, startingPoint.rotation);
            newProjectile.SetSpeed(projectileSpeed);
        }
    }

}
