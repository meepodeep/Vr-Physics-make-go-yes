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
        currentAngleX = can.localRotation.x; 
        currentAngleY = can.localRotation.y; 
        currentAngleZ = can.localRotation.z; 
        Debug.Log(currentAngleX);
        if (currentAngleX > 0){
            particles.SetActive(true);
        }else{
            particles.SetActive(false);
        }
    }
}
