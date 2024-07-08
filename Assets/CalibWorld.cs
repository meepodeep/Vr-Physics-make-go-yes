using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem; 
public class CalibWorld : MonoBehaviour
{
    public Transform World;
    public Transform PlayerCamera; 
    public InputActionProperty Calib; 
    public Transform AgainstTheKitchenFloor; 
    float PlayerHeightFromCounter; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool isCalibButtonPressed = Calib.action.ReadValue<float>() > 0.1f;
        if (isCalibButtonPressed == true){
            Calibrate();
        }
    }
    void Calibrate(){
        PlayerHeightFromCounter = PlayerCamera.transform.position.y - AgainstTheKitchenFloor.transform.position.y + 1; 
        World.transform.localScale = new Vector3(PlayerHeightFromCounter, PlayerHeightFromCounter, PlayerHeightFromCounter); 
        
    }
}
