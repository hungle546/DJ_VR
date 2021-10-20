using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private DiscController discCon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CheckSide();
    }

    private void CheckSide()
    {
        if (transform.localPosition.x < 0)
        {
            Debug.Log("left side");
            discCon.SpinLeft();
        }
        else if (transform.localPosition.x > 0)
        {
            Debug.Log("right side "+ transform.localPosition.x);
            discCon.SpinRight();
        }
        else if (transform.localPosition.x == 0)
        {
            //Debug.Log("zero");
        }
    }
}
