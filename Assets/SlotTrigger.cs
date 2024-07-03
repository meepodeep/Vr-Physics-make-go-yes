using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTrigger : MonoBehaviour
{
    public string ObjTag; 

    public void OnTriggerEnter(Collider other)
    {
        ObjTag = other.tag; 
    }
}
