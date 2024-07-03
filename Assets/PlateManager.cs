using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlateManager : MonoBehaviour
{
    [SerializeField]
    public SlotTrigger[] slots;
    public float points;
    private string[] RequestedTag;
    private bool implode;
    // Start is called before the first frame update
    void Start()
    {
        RequestedTag = new string[10];
        RequestedTag[0] = "TopBun"; 
        RequestedTag[1] = "Onion"; 
        RequestedTag[2] = "Lettuce"; 
        RequestedTag[3] = "Burger";
        RequestedTag[4] = "BottomBun";
    }

    public void RingUp()
    {
        if (slots[0].canTake == true || slots[1].canTake == true || slots[2].canTake == true || slots[3].canTake == true || slots[4].canTake == true){
        if (slots[0].ObjTag == RequestedTag[0])
        {
            points += 1;
        }
         if (slots[1].ObjTag == RequestedTag[1])
        {
            points += 1;
        }
         if (slots[2].ObjTag == RequestedTag[2])
        {
            points += 1;
        }
         if (slots[3].ObjTag == RequestedTag[3])
        {
            points += 1;
        }
        if (slots[4].ObjTag == RequestedTag[4])
        {
            points += 1;
        }
        slots[0].canTake = false; 
        slots[1].canTake = false; 
        slots[2].canTake = false; 
        slots[3].canTake = false; 
        slots[4].canTake = false; 
        }
        Debug.Log(points); 
        
    }

}

