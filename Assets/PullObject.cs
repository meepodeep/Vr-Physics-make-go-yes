using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public GameObject CurrentObject;
    public Collider CurrentObjectCollider;
    public bool IsGrabbing = false;
    void FixedUpdate()
    {
        bool isGrabButtonPressed = grabInputSource.action.ReadValue<float>() > 0.1f;
        if (CurrentObject != null && isGrabButtonPressed){
            CurrentObjectCollider.attachedRigidbody.AddForce((hand.position - CurrentObject.transform.position)* 40f, ForceMode.Force);
        }
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(hand.position, hand.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layersToHit))
        {
            if (IsGrabbing && isGrabButtonPressed && hit.distance >= .5){
            CurrentObject = hit.collider.gameObject;
            CurrentObjectCollider = hit.collider;
            IsGrabbing = false;
            }
            if (hit.distance >= .5){
            Debug.Log(hit.distance);
            Debug.DrawRay(hand.position, hand.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log(hit.collider.gameObject.name + "Did Hit");}
        }
        if(isGrabButtonPressed == false){
            IsGrabbing = true;
            CurrentObject = null;
            CurrentObjectCollider = null;
        }
    }
}
