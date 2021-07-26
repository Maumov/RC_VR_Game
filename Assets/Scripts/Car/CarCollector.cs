using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollector : MonoBehaviour, ICollector
{
    public void Collect(Collectable collectable) {
        Debug.Log(name + "collected " +collectable.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
