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

public class PlateManagerTutorial : MonoBehaviour
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
    public TutorialOrder order;
    float OrderTimer = 1;
    [SerializeField] TextMeshProUGUI PointText;
    public bool quotaMet;
    float gameTimer = 100;
    public GameObject[] icons;
    int TutorialStep = 0;
    [SerializeField] TextMeshProUGUI Instructions;
    // Start is called before the first frame update
    void Start()
    {
        icons = new GameObject[10];
        RequestedTag = new string[10];
        RequestedTag[0] = "TopBun"; 
        RequestedTag[1] = "Onion"; 
        RequestedTag[2] = "Burger"; 
        RequestedTag[3] = "Lettuce";
        RequestedTag[4] = "BottomBun";
        RequestedTag[5] = "PlateReal";
        RequestedTag[6] = "nein";
        ObjTag = new string[10]; 
        ObjTag[0] = "nein";
        ObjTag[1] = "nein";
        ObjTag[2] = "nein";
        ObjTag[3] = "nein";
        ObjTag[4] = "nein";
        ObjTag[5] = "nein";
    }
    void Update(){
    }
    void FixedUpdate()
    {
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
        
        RingUpTutorial();
        StartCoroutine(DelayResetTutorial());

    }
    public IEnumerator DelayResetTutorial(){
        yield return new WaitForSeconds(.1f);
        ObjectNumber = 0;
        canMove = false; 
        order.DeleteOldOrder();
        switch(TutorialStep){
            case 0:
            order.DisplayOrder1();
            Instructions.text = "To start every order, you must grab a plate, for your first order grab one and submit it with the button.";
            break;
            case 1:
            order.DisplayOrder2();
            Instructions.text = "Your current order will be displayed on the board, press the button next to the grill to turn it on.";
            break;
            case 2:
            order.DisplayOrder2();
            break;
            case 3:
            order.DisplayOrder3();
            break;
        }
        
        ObjTag[0] = "nein";
        ObjTag[1] = "nein";
        ObjTag[2] = "nein";
        ObjTag[3] = "nein";
        ObjTag[4] = "nein";
        ObjTag[5] = "nein";

    }
    public void RingUpTutorial()
    {
        if (ObjTag[0] == RequestedTag[order.Index[0]]&&ObjTag[1] == RequestedTag[order.Index[1]]&&ObjTag[2] == RequestedTag[order.Index[2]]&&ObjTag[3] == RequestedTag[order.Index[3]]&&ObjTag[4] == RequestedTag[order.Index[4]])
        { 
            TutorialStep+=1;
        }else{
        }
       
        PointText.text = "Points:" + points.ToString();
        Debug.Log(points); 
        
    }

}

