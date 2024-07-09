using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField]
    public Transform[] Slots;
    [SerializeField]
    public GameObject[] Foods;
    public int[]Index;
    public GameObject[] icons;
    // Start is called before the first frame update
    void Start()
    {
        Index = new int[10];
        icons = new GameObject[6];
        DisplayOrder();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void DisplayOrder(){
        Index[0] = 0;
        Index[1] = Mathf.Clamp(Random.Range(0,4), 1, 3);
        Index[2] = Mathf.Clamp(Random.Range(0,4), 1, 3);
        Index[3] = Mathf.Clamp(Random.Range(0,4), 1, 3);
        Index[4] = 4;
        Instantiate(Foods[Index[0]], Slots[0].transform.position, Slots[0].transform.rotation);
        Instantiate(Foods[Index[1]], Slots[1].transform.position, Slots[0].transform.rotation);
        Instantiate(Foods[Index[2]], Slots[2].transform.position, Slots[0].transform.rotation);
        Instantiate(Foods[Index[3]], Slots[3].transform.position, Slots[0].transform.rotation);
        Instantiate(Foods[Index[4]], Slots[4].transform.position, Slots[0].transform.rotation);
    }
    public void DeleteOldOrder(){
        icons = GameObject.FindGameObjectsWithTag("Icon");
        Destroy(icons[0]);
        Destroy(icons[1]);
        Destroy(icons[2]);
        Destroy(icons[3]);
        Destroy(icons[4]);

    }
}
