using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CalibHeight : MonoBehaviour
{
    public GameObject playerBody; 
    public GameObject physicsRig; 
    float PlayerHeight = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        playerBody.transform.position = new Vector3(0,-PlayerHeight,0);
        physicsRig.transform.position = new Vector3(0,PlayerHeight,0);
        playerBody.transform.localScale = new Vector3(1,PlayerHeight*1.9f,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
