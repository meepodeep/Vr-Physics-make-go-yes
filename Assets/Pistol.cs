using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Pistol : MonoBehaviour
{
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x =>StartShoot());
        grabInteractable.deactivated.AddListener(x =>StopShoot());
    }
    public void StartShoot()
    {
        particles.Play();
    }
      public void StopShoot()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
