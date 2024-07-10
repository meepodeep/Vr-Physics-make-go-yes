using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TutorialManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Instructions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instructions.text = "To start every order, you must grab a plate from the shelves above, grab the handles and pull yourself up to reach";
    }
}
