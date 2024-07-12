using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanManager : MonoBehaviour
{
    public GameObject particles; 
    public Transform can;
    float currentAngleY; 
    float currentAngleX; 
    float currentAngleZ; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float dotResult = Vector3.Dot(can.forward, Vector3.up);
        Debug.Log(dotResult);
        if (dotResult <=0){
            particles.SetActive(true);
        }else{
            particles.SetActive(false);
        }


    }
}
