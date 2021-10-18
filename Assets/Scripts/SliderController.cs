using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (transform.position.x < 0)
        {
            Debug.Log("left side");
        }
        else
        {
            Debug.Log("right side");
        }
    }
}
