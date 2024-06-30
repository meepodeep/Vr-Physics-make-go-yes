using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grillable : MonoBehaviour
{
    float grillPercent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (grillPercent >= 10  && grillPercent < 15){
        Cooked();
       }
        if (grillPercent >= 15){
        Burnt();
       }
    }
     void OnTriggerStay(Collider other)
    {
            if(other.gameObject.CompareTag("Grill"))
            {   
                Cook();
            }
    }
    void Cook(){
        Mathf.Clamp(grillPercent,0f, 15f);
        grillPercent += 1f * Time.deltaTime;
    }
    void Cooked()
    {
    Debug.Log("cooked");
    }
     void Burnt()
    {
    Debug.Log("burnt");
    }
}
