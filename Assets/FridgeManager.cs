using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FridgeManager : MonoBehaviour
{
    public GameObject food;
    public FridgeCollider fc;
    bool canSpawn = false; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(fc.doorClosed);
        if(fc.doorClosed == false && canSpawn == true){
        Instantiate(food, new Vector3(0,0,0), Quaternion.Euler(-90,0,0));
        canSpawn = false;
        }
        if(fc.doorClosed == true){
            
            Destroy(GameObject.FindWithTag("FoodStack"));
            canSpawn = true;
        }
    }
}
