using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlateManager : MonoBehaviour
{
    public float points;
    private string[] RequestedTag;
    private bool implode;
    bool IsPressed = false; 
    public string[] ObjTag; 
    public bool canTake;
    float ObjectNumber; 
    [SerializeField]
    float goDown;
    public Transform ResetPoint;
    public Transform Scanner; 
    // Start is called before the first frame update
    void Start()
    {
        goDown = ResetPoint.position.z; 
        RequestedTag = new string[10];
        RequestedTag[0] = "TopBun"; 
        RequestedTag[1] = "Onion"; 
        RequestedTag[2] = "Lettuce"; 
        RequestedTag[3] = "Burger";
        RequestedTag[4] = "BottomBun";
        ObjTag = new string[10]; 
    }
    void Update()
    {
        if (IsPressed == true){
            goDown -= .1f; 
            Scanner.Translate(0,0,goDown); 
        }else{
            goDown = ResetPoint.position.z; 
        }
    }
    public void Press(){
        IsPressed = true;
    }
    public void UnPress(){
        IsPressed = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "plate"){
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
        }else{
            ObjectNumber = 0;
        }
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

