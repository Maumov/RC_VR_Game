using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    //public GameObject[] waypoints;
    public UnityStandardAssets.Utility.WaypointCircuit circuit;
    int currentWP = 0;

    float speed = 1f;
    float accuracy = 1f;
    float rotSpeed = 0.4f;
    private void Start() {
        //TODO: mejorar el llenar la llista de waypoints.
        //waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    private void LateUpdate() {
        //TODO cambiar el movimiento aqui... para que sean señales para el carro...
        if(circuit.Waypoints.Length == 0) {
            return;
        }

        Vector3 lookAtGoal = new Vector3(circuit.Waypoints[currentWP].position.x,
                                        transform.position.y, 
                                        circuit.Waypoints[currentWP].transform.position.z);
        Vector3 direction = lookAtGoal - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                              Quaternion.LookRotation(direction),
                                              Time.deltaTime * rotSpeed);
        if(direction.magnitude < accuracy) {
            currentWP++;
            if(currentWP >= circuit.Waypoints.Length) {
                currentWP = 0;
            }
        }
        transform.Translate(0f, 0f, speed * Time.deltaTime);
    }
}
