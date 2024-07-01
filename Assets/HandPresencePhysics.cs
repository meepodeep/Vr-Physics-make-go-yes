using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    private Collider[] handColliders;
    float differenceStrafe;
    float differenceUp;
    float differenceForward;
    float correctionForce = 2000;
    [SerializeField]
    private float _maxLinearVelocity = 20;
    [SerializeField]
    [Range(-10, 10)]
    private float _AxisP, _AxisI, _AxisD;
    private PID _yAxisPIDController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
        rb.maxLinearVelocity = _maxLinearVelocity;
        _yAxisPIDController = new PID(_AxisP, _AxisI, _AxisD); 
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
        differenceStrafe = target.transform.position.x - rb.transform.position.x;
        differenceForward = target.transform.position.z - rb.transform.position.z;
        differenceUp = target.transform.position.y - rb.transform.position.y;
        float yMoveCorrection = _yAxisPIDController.GetOutput(differenceUp, Time.fixedDeltaTime);
        Mathf.Clamp(differenceForward, -2,2);
        Mathf.Clamp(differenceStrafe, -2,2);
        Mathf.Clamp(differenceUp, -2,2);
        Debug.Log(differenceForward);
        rb.AddForce( transform.up * differenceUp * correctionForce* yMoveCorrection);
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
