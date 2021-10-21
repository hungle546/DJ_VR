using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class SpecialEffects : XRBaseInteractable
{
    
    [SerializeField] private GameObject particles;
    [SerializeField] private GameObject particles2;
    public UnityEvent onPress = null;
    private bool previousPressed = false;
    private float previousHandHeight = 0.9f;
    private XRBaseInteractor hoverInteractor = null;
    private float ymin = 0.0f;
    private float ymax = 0.0f;
    private bool isPlaySound = false;

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        StartPress(args.interactor);
    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        EndPress(args.interactor);
    }

    private void StartPress(XRBaseInteractor interactor)
    {
        hoverInteractor = interactor;
        previousHandHeight = GetLocalYPosition(hoverInteractor.transform.position);


    }

    private void EndPress(XRBaseInteractor interactor)
    {
        hoverInteractor = null;
        previousHandHeight = 0.0f;

        previousPressed = false;
        
        SetYPosition(ymax);
        
    }

    void Start()
    {
        Debug.Log("hi");
        particles.SetActive(false);
        particles2.SetActive(false);
        setMinMax();
    }

    private void setMinMax()
    {
        Collider collider = GetComponent<Collider>();
        ymin = transform.localPosition.y - (collider.bounds.size.y * 0.5f);
        ymax = transform.localPosition.y;

    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (hoverInteractor)
        {
            float newhandheight = GetLocalYPosition(hoverInteractor.transform.position);
            float handDifference = previousHandHeight - newhandheight;
            previousHandHeight = newhandheight;

            float newPosition = transform.position.y - handDifference;
            SetYPosition(newPosition);
            
            CheckPress();
            //audioSource.PlayOneShot(clip,1f);
        }
    }

    private float GetLocalYPosition(Vector3 position)
    {
        Vector3 localPosition = transform.root.InverseTransformPoint(position);
        return localPosition.y;
    }

    private void SetYPosition(float position)
    {
        Vector3 newPosition = transform.localPosition;
        //newPosition.y = Mathf.Clamp(position, ymin, ymax);
        transform.localPosition = newPosition;
        
    }

    private void CheckPress()
    {
        AudioSource sound = GetComponent<AudioSource>();
        
        bool inPosition = this.inPosition();

        if (inPosition && inPosition != previousPressed)
        {
            onPress.Invoke();
        }
        particles.SetActive(true);
        particles2.SetActive(true);
        previousPressed = inPosition;
        if (!isPlaySound)
        {
            sound.PlayOneShot(sound.clip,0.5f);
            particles.SetActive(true);
            particles2.SetActive(true);
            isPlaySound = true;
            StartCoroutine("PressDelay");
        }

    }

    private IEnumerator PressDelay()
    {
        yield return new WaitForSeconds(5f);
        isPlaySound = false;
        particles.SetActive(false);
        particles2.SetActive(false);
    }

    private bool inPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y,ymin,ymin + 0.01f);
        return transform.localPosition.y == inRange;
        
    }
    
    
}