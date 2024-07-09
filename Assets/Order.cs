using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField]
    public Transform[] Slots;
    [SerializeField]
    public GameObject[] Foods;
    public int[]Index;
    // Start is called before the first frame update
    void Start()
    {
        Index = new int[10];
        Index[0] = Random.Range(0,4);
        Index[1] = Random.Range(0,4);
        Index[2] = Random.Range(0,4);
        Index[3] = Random.Range(0,4);
        Index[4] = Random.Range(0,4);
        DisplayOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DisplayOrder(){
        Instantiate(Foods[Index[0]], Slots[0].transform.position, Quaternion.identity);
        Instantiate(Foods[Index[1]], Slots[1].transform.position, Quaternion.identity);
        Instantiate(Foods[Index[2]], Slots[2].transform.position, Quaternion.identity);
        Instantiate(Foods[Index[3]], Slots[3].transform.position, Quaternion.identity);
        Instantiate(Foods[Index[4]], Slots[4].transform.position, Quaternion.identity);
    }
}
