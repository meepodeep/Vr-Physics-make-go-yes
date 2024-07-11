using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanManager : MonoBehaviour
{
    public ParticleSystem particles; 
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
        currentAngleY = Mathf.Abs(can.localEulerAngles.y); 
        currentAngleX = Mathf.Abs(can.localEulerAngles.x); 
        currentAngleZ = Mathf.Abs(can.localEulerAngles.z); 
        if (currentAngleY >= 80|| currentAngleX >= 80 || currentAngleZ >= 80){
            particles.Play();
        }else{
            particles.Stop();
        }
    }
}
