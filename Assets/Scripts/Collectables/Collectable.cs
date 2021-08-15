using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    public delegate void OnCollect();
    public event OnCollect OnPickUp;
    public float speed = 1;

    void Start() {
        OnPickUp += Collect;
    }
    private void Update() 
    {
        transform.Rotate(Vector3.up, speed);    
    }
    
    public void Collect() {
        gameObject.SetActive(false);
        Debug.Log("Item Collected: "+ name);
    }

    public virtual void OnTriggerEnter(Collider other) {
        ICollector col = other.GetComponent<ICollector>();
        if(col != null) {
            OnPickUp();
            col.Collect(this);
        }
    }
}
