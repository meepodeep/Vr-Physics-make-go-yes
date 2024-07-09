using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

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
    public Order order;
    float OrderTimer = 1;
    [SerializeField] private Image Timer = null;
    [SerializeField] TextMeshProUGUI PointText;
    // Start is called before the first frame update
    void Start()
    {
        RequestedTag = new string[10];
        RequestedTag[0] = "TopBun"; 
        RequestedTag[1] = "Onion"; 
        RequestedTag[2] = "Burger"; 
        RequestedTag[3] = "Lettuce";
        RequestedTag[4] = "BottomBun";
        RequestedTag[5] = "PlateReal";
        ObjTag = new string[10]; 
    }
    void FixedUpdate()
    {
        Timer.fillAmount = OrderTimer;
        OrderTimer -= .01f * Time.fixedDeltaTime; 
        if(OrderTimer <= 0){
            FindObjectOfType<AudioManager>().Play("Ring");
            points = points - 5;
            NewOrder();
        }
        if (IsPressed == true && canMove == true){
        move = -.1f;
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
        
        if (other.gameObject.CompareTag("Plate")){
            NewOrder();
            OrderTimer = 1;
            FindObjectOfType<AudioManager>().Play("Ding");
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
            case 6:
            ObjTag[5] = other.tag;
            break;
        }
        Destroy(other.gameObject); 
        }
        }
    }
    public void Press(){
    IsPressed = true;
    }
    public void UnPress(){
        IsPressed = false;
    }
    public void NewOrder()
    {
        
        RingUp();
        OrderTimer = 1;
        ObjectNumber = 0;
        canMove = false; 
        order.DeleteOldOrder();
        order.DisplayOrder();
        ObjTag[0] = "nein";
        ObjTag[1] = "nein";
        ObjTag[2] = "nein";
        ObjTag[3] = "nein";
        ObjTag[4] = "nein";
        ObjTag[5] = "nein";

    }
    public void RingUp()
    {
        if (ObjTag[5] == RequestedTag[5])
        {
            if (ObjTag[0] == RequestedTag[0])
        {
            points += 1;
        }else{
            points -= 1;
        }
         if (ObjTag[1] == RequestedTag[order.Index[1]])
        {
            points += 1;
        }else{
            points -= 1;
        }
         if (ObjTag[2] == RequestedTag[order.Index[2]])
        {
            points += 1;
        }else{
            points -= 1;
        }
         if (ObjTag[3] == RequestedTag[order.Index[3]])
        {
            points += 1;
        }else{
            points -= 1;
        }
        if (ObjTag[4] == RequestedTag[order.Index[4]])
        {
            points += 1;
        }else{
            points -= 1;
        }
        }else{
            points -= 5;
        }
        
        PointText.text = "Points:" + points.ToString();
        Debug.Log(points); 
        
    }

}

