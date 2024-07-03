using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;


public class Slicer : MonoBehaviour
{
    // all of the foods sliced//
    public GameObject OnionCut;
    //public GameObject BurgerCut;
    //public GameObject PotatoCut;
    public GameObject LettuceCut;
    private Vector3 SpawnVector; 
    public GameObject[] foodsCut; 
    void Start(){
        foodsCut = new GameObject[10];
        foodsCut[0] = LettuceCut;
        foodsCut[1] = OnionCut;
    }
    public void OnTriggerEnter(Collider other)
    {
        SpawnVector = other.gameObject.transform.position;
        

        switch(other.tag){
            case "Onion":
            Destroy(other.gameObject);
            Instantiate(foodsCut[1], SpawnVector, Quaternion.identity); 
            Instantiate(foodsCut[1], SpawnVector, Quaternion.identity);
            break;
            case "Lettuce":
            Destroy(other.gameObject);
            Instantiate(foodsCut[0], SpawnVector, Quaternion.identity); 
            Instantiate(foodsCut[0], SpawnVector, Quaternion.identity); 
            break;

        }
    }
}
