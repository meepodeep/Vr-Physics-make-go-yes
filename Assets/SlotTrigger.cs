using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTrigger : MonoBehaviour
{
    public string ObjTag; 

    public void OnTriggerEnter(Collider other)
    {
        other.tag = ObjTag; 
    }
}
