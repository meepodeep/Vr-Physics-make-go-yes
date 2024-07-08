using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem; 
public class CalibWorld : MonoBehaviour
{
    public Rigidbody World;
    public Transform PlayerCamera; 
    public InputActionProperty Calib; 
    public Transform AgainstTheKitchenFloor; 
    float PlayerHeightFromCounter = 1f; 
    bool isCalibButtonPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isCalibButtonPressed == true){
            Calibrate();
            isCalibButtonPressed = false;
        }else if(isCalibButtonPressed == false){
            isCalibButtonPressed = Calib.action.ReadValue<float>() > 0.1f;
        }
    }
    void Calibrate(){
        PlayerHeightFromCounter = PlayerCamera.transform.position.y - AgainstTheKitchenFloor.transform.position.y; 
        World.velocity = new Vector3(0, PlayerHeightFromCounter, 0); 
        
    }
}
