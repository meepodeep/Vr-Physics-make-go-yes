using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.UI;

public class PhysicsButton : MonoBehaviour
{
    public Transform buttonTop;
    public Transform buttonBase;
    public float force = 10;
    public bool isPressed;
    public Collider[] CollidersToIgnore;
    public UnityEvent onPressed;
    public UnityEvent onReleased;
    private float distance;
    public float threshold = 0.05f;

    // Start is called before the first frame update
    void Start()
    {

    }
   void FixedUpdate()
    {
        distance = buttonTop.localPosition.y-buttonBase.localPosition.y;
        Debug.Log(distance);
        if(distance <= threshold){
            Pressed();
            onPressed.Invoke();
        }else{
            onReleased.Invoke();
            Released();
        }
    }

    void Pressed(){
        
        isPressed = true;
    }

    void Released(){
        
        isPressed = false;
    }
}