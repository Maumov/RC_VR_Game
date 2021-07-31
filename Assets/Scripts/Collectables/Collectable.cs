using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    public delegate void OnCollect();
    public event OnCollect OnPickUp;

    void Start() {
        OnPickUp += Collect;
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
