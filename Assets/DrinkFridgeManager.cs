using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DrinkFridgeManager : MonoBehaviour
{
    public GameObject food;
    public FridgeCollider fc;
    bool canSpawn = false; 
    public GameObject[] foodsInFridge;
    int foodNumber = 1;
    bool canPlay = false;
    // Start is called before the first frame update
    void Awake()
    {
        foodsInFridge = new GameObject[500];
        canPlay = true;
    }
    public void OnTriggerStay(Collider other)
    {
        if(fc.doorClosed == true && canPlay == true){
        if(other.gameObject != null){
        foodsInFridge[foodNumber] = other.gameObject; 
        }
        foodNumber +=1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(fc.doorClosed == false && canPlay == true){
            canSpawn = true;
        }
        if(fc.doorClosed == true && canSpawn == true && canPlay == true){
            if(foodNumber > 0){
            foreach (GameObject food in foodsInFridge){
                Destroy(food);
            }
            foodNumber = 0;
            }
            Instantiate(food, new Vector3(0.892f,1.182332f,0.697f), Quaternion.Euler(0,0,0));
            canSpawn = false;
        }
        
    }
}
