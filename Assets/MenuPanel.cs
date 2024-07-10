using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.UI;

public class MenuPanel : MonoBehaviour
{
    public Transform buttonTopTutorial;
    public Transform buttonTopPlay;
    public Transform buttonTopExit;
    public Transform buttonBase;
    public UnityEvent PlayOnPressed;
    public UnityEvent PlayOnReleased;
    public UnityEvent TutorialOnPressed;
    public UnityEvent TutorialOnReleased;
    public UnityEvent ExitOnPressed;
    public UnityEvent ExitOnReleased;
    float threshold =  -0.0000003875605f;
    private float TutorialDistance;
    private float PlayDistance;
    private float ExitDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TutorialDistance = buttonTopTutorial.localPosition.z-buttonBase.localPosition.z;
        if(TutorialDistance <= threshold){
            TutorialOnReleased.Invoke();
        }else{
            TutorialOnPressed.Invoke();
        }
        Debug.Log(PlayDistance);
        PlayDistance = buttonTopPlay.localPosition.z-buttonBase.localPosition.z;
        if(PlayDistance <= threshold){
            PlayOnReleased.Invoke();
        }else{
            PlayOnPressed.Invoke();
        }
        ExitDistance = buttonTopExit.localPosition.z-buttonBase.localPosition.z;
        if(ExitDistance <= threshold){
            ExitOnReleased.Invoke();
        }else{
            ExitOnPressed.Invoke();
        }
    }
    public void Implode(){
        Application.Quit();
        Debug.Log("Implode");
    }
}
