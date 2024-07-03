using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;


public class Slicer : MonoBehaviour
{

    private Vector3 SpawnVector; 
    [SerializeField]
    public GameObject[] foodsCut; 
    void Start(){

    }
    public void OnTriggerEnter(Collider other)
    {
        SpawnVector = other.gameObject.transform.position;
        

        switch(other.tag){
            case "OnionUncut":
            Destroy(other.gameObject);
            Instantiate(foodsCut[1], SpawnVector, Quaternion.identity); 
            Instantiate(foodsCut[1], SpawnVector, Quaternion.identity);
            break;
            case "LettuceUncut":
            Destroy(other.gameObject);
            Instantiate(foodsCut[0], SpawnVector, Quaternion.identity); 
            Instantiate(foodsCut[0], SpawnVector, Quaternion.identity); 
            break;

        }
    }
}
