using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpotlightChange : MonoBehaviour
{
    float duration = 0.5f;
    Color color0 = Color.green;
    Color color1 = Color.blue;

    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
        // set light color
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }
    
}
