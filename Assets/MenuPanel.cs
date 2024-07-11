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
    float threshold =  -0.00000002337221f;
    private float TutorialDistance;
    private float PlayDistance;
    private float ExitDistance;
    private float ExitThreshold;
    private float PlayThreshold;
    private float TutorialThreshold;
    bool CanToggle = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayThreshold());
    }
    public IEnumerator delayThreshold(){
        yield return new WaitForSeconds(.1f);
        TutorialThreshold = TutorialDistance/1.11f;
        ExitThreshold = ExitDistance/1.11f;
        PlayThreshold = PlayDistance/1.11f;
        CanToggle = true;
    }
    // Update is called once per frame
    void Update()
    {
        
        TutorialDistance = buttonTopTutorial.localPosition.z-buttonBase.localPosition.z;
        if(TutorialDistance >= TutorialThreshold && CanToggle == true){
            TutorialOnPressed.Invoke();
            
        }else{
            TutorialOnReleased.Invoke();
        }
        
        PlayDistance = buttonTopPlay.localPosition.z-buttonBase.localPosition.z;
        Debug.Log(PlayDistance);
        if(PlayDistance >= PlayThreshold && CanToggle == true){
            PlayOnPressed.Invoke();
        }else{
            PlayOnReleased.Invoke();
        }
        ExitDistance = buttonTopExit.localPosition.z-buttonBase.localPosition.z;
        if(ExitDistance >= ExitThreshold && CanToggle == true){
            ExitOnPressed.Invoke();
        }else{
            ExitOnReleased.Invoke();
            
        }
    }
    public void Implode(){
        Application.Quit();
        Debug.Log("Implode");
    }
}
