using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class handButton : XRBaseInteractable

{
    public UnityEvent onPress = null;
    private bool previousPressed = false;
    private float previousHandHeight = 0.9f;
    private XRBaseInteractor hoverInteractor = null;
    private float ymin = 0.0f;
    private float ymax = 0.0f;
    private bool isPlaySound = false;
    private Animator ac; 

    [SerializeField] private DiscController discCon;
    [SerializeField] private GameObject crowd;

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
        ac = crowd.GetComponent<Animator>();
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
       // AudioSource audio = GetComponent<AudioSource>();
        
        bool inPosition = this.inPosition();

        if (inPosition && inPosition != previousPressed)
        {
            onPress.Invoke();
        }

        previousPressed = inPosition;
        //Debug.Log("button Pressed");
        if (!isPlaySound)
        {
            if (!discCon.GetIsPlaying())
            {
                discCon.PlayBoth();
                Debug.Log("starting music");
                isPlaySound = true;
                ac.SetInteger("DanceIndex", Random.Range(0,3));
                ac.SetBool("isDance", true);
                ac.SetBool("IsIdle", false);
                StartCoroutine("PressDelay");
            }
            else if (discCon.GetIsPlaying())
            {
                discCon.StopBoth();
                Debug.Log("stopping music"); 
                isPlaySound = true;
                ac.SetBool("isDance", false);
                ac.SetBool("IsIdle", true);
                StartCoroutine("PressDelay");
            }
        }
    }
    
    private IEnumerator PressDelay()
    {
        yield return new WaitForSeconds(2f);
        isPlaySound = false;
    }

    private bool inPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y,ymin,ymin + 0.01f);
        return transform.localPosition.y == inRange;
        
    }
    
    
}