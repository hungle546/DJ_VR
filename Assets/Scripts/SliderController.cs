using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private DiscController discCon;
    private float volumePercent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckSide();
    }

    private void CheckSide()
    {
        if (transform.localPosition.x < -0.474)
        {
            Debug.Log("left side");
            discCon.MuteRight();
        }
        else if (transform.localPosition.x > 0.475 && transform.localPosition.x < 0.5)
        {
            Debug.Log("right side "+ transform.localPosition.x);
            discCon.MuteLeft();
        }
        else if (transform.localPosition.x < 0.475 && transform.localPosition.x > -0.475)
        {
            VolumeCalculator();
        }
    }

    private void VolumeCalculator()
    {
        double volPercent = transform.localPosition.x / 0.475;
        volumePercent = Convert.ToSingle(volPercent);
        //Debug.Log(volumePercent);
        discCon.AudjustVolume(volumePercent);
    }
}
