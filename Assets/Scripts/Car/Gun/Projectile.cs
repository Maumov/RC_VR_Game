using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private LayerMask collisionMask;
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float damage = 1;
    private float moveDistance;

    public void SetSpeed(float newSpeed) 
    {
        speed = newSpeed;
    }
    void Update()
    {
        moveDistance = speed * Time.deltaTime;
        CheckCollision(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    public void CheckCollision(float moveDistance)
    {
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, moveDistance, collisionMask))
        {
            OnHitObject(hit);        
        }
    }

    public void OnHitObject(RaycastHit hit)
    {
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        if(damageableObject != null)
        {
            damageableObject.TakeHit(damage, hit);
        }
        Destroy(gameObject); 

    }
}
