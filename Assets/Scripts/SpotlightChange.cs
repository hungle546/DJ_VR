using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpotlightChange : MonoBehaviour
{
    [SerializeField] private SliderController slider;
    float duration = 0.5f;
    Color color0 = Color.green;
    Color color1 = Color.blue;
    Color color2 = Color.red;
    Color color3 = Color.cyan;
    Color color4 = Color.magenta;
    Color color5 = Color.yellow;

    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
        lt.color = color4;
    }

    void Update()
    {
        // set light color
        //float t = Mathf.PingPong(Time.time, duration) / duration;
        //lt.color = Color.Lerp(color0, color1, t);
        SliderLight();
    }

    private void SliderLight()
    {
        if (slider.GetPosition() > 0.475 && slider.GetPosition() < 0.5)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            lt.color = Color.Lerp(color0, color1, t);
        }
        else if (slider.GetPosition() < -0.474)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            lt.color = Color.Lerp(color2, color3, t);
        }
        else if (slider.GetPosition() < 0.475 && slider.GetPosition() > -0.475)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            lt.color = Color.Lerp(color4, color5, t);
        }
    }
    
}
