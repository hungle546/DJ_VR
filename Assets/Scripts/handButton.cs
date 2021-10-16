using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class handButton : XRBaseInteractable

{
    public UnityEvent onPress = null;
    private bool previousPressed = false;
    private float previousHandHeight = 0.9f;
    private XRBaseInteractor hoverInteractor = null;
    private float ymin = 0.0f;
    private float ymax = 0.0f;

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

    private void start()
    {
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
        newPosition.y = Mathf.Clamp(position, ymin, ymax);
        transform.localPosition = newPosition;
        
    }

    private void CheckPress()
    {
        bool inPosition = this.inPosition();

        if (inPosition && inPosition != previousPressed)
        {
            onPress.Invoke();
        }

        previousPressed = inPosition;
        Debug.Log("button Pressed");
    }

    private bool inPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y,ymin,ymax);
        return transform.localPosition.y == inRange;
        
    }
    
    
}