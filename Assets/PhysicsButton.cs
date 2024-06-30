using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    public Transform buttonTop;
    public float force = 10;
    private float upperLowerDiff;
    public bool isPressed;
    private bool prevPressedState;
    public Collider[] CollidersToIgnore;
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(buttonTop.position.y); 
    }

   void FixedUpdate()
    {

    }

    void Pressed(){
        prevPressedState = isPressed;
        onPressed.Invoke();
    }

    void Released(){
        prevPressedState = isPressed;
        onReleased.Invoke();
    }
}