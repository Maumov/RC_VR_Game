using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private float rotSpeed;
    [SerializeField]
    private float movSpeed;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private LayerMask layerToHit;
    private Camera mainCamera;
    private float step;
    private float lastDistance;

    // Start is called before the first frame update
    private void Awake() 
    {
        mainCamera = GetComponent(typeof(Camera)) as Camera;
    }

    // Update is called once per frame
    void Update()
    {
        FollowTargetRot();
        FollowTargetPos();
    }

    public void FollowTargetRot()
    {
        step = rotSpeed * Time.deltaTime;
        Vector3 targetDirection = target.transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void FollowTargetPos()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance > maxDistance)
        {
            step = movSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, 
                                        new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), step);
            lastDistance = Vector3.Distance(transform.position, target.transform.position);
        } else
        {
            // Vector3 maxDistanceToMove = new Vector3 (transform.position.x + maxDistance, transform.position.y, transform.position.z + maxDistance);
            // float camSpeed = distance/lastDistance;
            // Vector3 newPos = Vector3.Lerp(transform.position, maxDistanceToMove, camSpeed);
            // transform.position = newPos * Time.deltaTime;
            // Debug.Log(camSpeed);
            // Debug.Log(maxDistanceToMove);
        }
    }
}
