using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlateManager : MonoBehaviour
{
    public float points;
    private string[] RequestedTag;
    private bool implode;
    bool IsPressed = true; 
    public string[] ObjTag; 
    public bool canTake;
    float ObjectNumber; 
    [SerializeField]
    public Rigidbody Scanner; 
    public Transform ScannerTransform;
    bool canMove = true;
    float move;
    // Start is called before the first frame update
    void Start()
    {
        RequestedTag = new string[10];
        RequestedTag[0] = "TopBun"; 
        RequestedTag[1] = "Onion"; 
        RequestedTag[2] = "Lettuce"; 
        RequestedTag[3] = "Burger";
        RequestedTag[4] = "BottomBun";
        ObjTag = new string[10]; 
    }
    void FixedUpdate()
    {
        if (IsPressed == true && canMove == true){
        move = -.01f;
        Scanner.AddForce(transform.up * move);
        }else{
            move = 0f;
            Scanner.velocity = new Vector3(0f, 0f, 0f);
            ScannerTransform.localPosition = new Vector3(0,0,0);
            canMove = true; 
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("plate");
        if (other.gameObject.CompareTag("Plate")){
        
        ObjectNumber = 0;
        canMove = false; 
        }else{
        if(IsPressed == true){
        ObjectNumber +=1;
        switch(ObjectNumber){
            case 1:
            ObjTag[0] = other.tag;
            break;
            case 2:
            ObjTag[1] = other.tag;
            break;
            case 3:
            ObjTag[2] = other.tag;
            break;
            case 4:
            ObjTag[3] = other.tag;
            break;
            case 5:
            ObjTag[4] = other.tag;
            break;
        }
        }
        }
    }
    public void Press(){
    IsPressed = true;
    }
    public void UnPress(){
        IsPressed = true;
    }
    public void RingUp()
    {

        if (ObjTag[0] == RequestedTag[0])
        {
            points += 1;
        }
         if (ObjTag[1] == RequestedTag[1])
        {
            points += 1;
        }
         if (ObjTag[2] == RequestedTag[2])
        {
            points += 1;
        }
         if (ObjTag[3] == RequestedTag[3])
        {
            points += 1;
        }
        if (ObjTag[4] == RequestedTag[4])
        {
            points += 1;
        }
        Debug.Log(points); 
    }

}

