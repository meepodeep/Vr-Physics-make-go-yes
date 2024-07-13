using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.InputSystem;
public class PullObject : MonoBehaviour
{
    Ray ray;
    RaycastHit hit; 
    public Transform hand; 
    public LayerMask layersToHit;
    public float maxDistance = 100;
    public InputActionProperty grabInputSource;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    
    void FixedUpdate()
    {
        bool isGrabButtonPressed = grabInputSource.action.ReadValue<float>() > 0.1f;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(hand.position, hand.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layersToHit))
        {
            if (hit.distance <= 2 && isGrabButtonPressed){
                hit.collider.transform.position = hand.transform.position;
            }
            Debug.Log(hit.distance);
            Debug.DrawRay(hand.position, hand.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log(hit.collider.gameObject.name + "Did Hit");
        }
    }
}
