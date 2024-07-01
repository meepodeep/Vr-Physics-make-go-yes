using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HandPresencePhysics : MonoBehaviour
{
    [SerializeField]
    PID Ycontroller; 
    public Transform target;
    private Rigidbody rb;
    private Collider[] handColliders;
    float differenceStrafe;
    float differenceUp;
    float differenceForward;
    float correctionForce = 400;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
    }
    public void EnableHandCollider()
    {
        foreach (var item in handColliders){
            item.enabled = true;
        }
    }
    public void EnableHandColliderDelat(float delay){
        Invoke("EnableHandCollider", delay);
    }
    public void DisableHandCollider()
    {
          foreach (var item in handColliders){
            item.enabled = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float inputUp = Ycontroller.Update(Time.fixedDeltaTime, rb.transform.position.y, target.transform.position.y); 
        rb.AddForce(transform.up * correctionForce * inputUp);
        Debug.Log(inputUp);
        differenceStrafe = target.transform.position.x - rb.transform.position.x;
        differenceForward = target.transform.position.z - rb.transform.position.z;


        AddForces();

        
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
    void AddForces(){
        rb.AddForce( transform.forward * differenceForward*Time.fixedDeltaTime* correctionForce);
        
        rb.AddForce(transform.right * differenceStrafe* Time.fixedDeltaTime * correctionForce);
    }
}
