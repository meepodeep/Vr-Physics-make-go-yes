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
    float threshold = -0.06f;
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
        if(TutorialDistance >= threshold){
            TutorialOnPressed.Invoke();
        }else{
            TutorialOnReleased.Invoke();
        }
        PlayDistance = buttonTopPlay.localPosition.z-buttonBase.localPosition.z;
        if(PlayDistance >= threshold){
            PlayOnPressed.Invoke();
        }else{
            PlayOnReleased.Invoke();
        }
        ExitDistance = buttonTopExit.localPosition.z-buttonBase.localPosition.z;
        if(ExitDistance >= threshold){
            ExitOnPressed.Invoke();
        }else{
            ExitOnReleased.Invoke();
        }
    }
}
