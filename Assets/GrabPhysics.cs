using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GrabPhysics : MonoBehaviour
{
    public InputActionProperty grabInputSource; 
    public float radius = 0.1f;
    public LayerMask grabLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool isGrabButtonPressed = grabInputSource.action.ReadValue<float>() > 0.1f;
        if(isGrabButtonPressed)
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position,radius,grabLayer, QueryTriggerInteraction.Ignore); 
            if(nearbyColliders.Length >0)
            {
                Rigidbody nearbyRigidbody = nearbyColliders[0].attachedRigidbody;
            }
        }
    }
}
