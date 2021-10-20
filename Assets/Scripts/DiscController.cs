using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscController : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    private Transform leftRotation;
    private Transform rightRotation;
    private float spinSpeed = 80f;
    private AudioSource leftAudio;
    private AudioSource rightAudio;
    // Start is called before the first frame update
    void Start()
    {
        leftRotation = left.GetComponent<Transform>();
        rightRotation = right.GetComponent<Transform>();
        leftAudio = left.GetComponent<AudioSource>();
        rightAudio = right.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SpinLeft();
        SpinRight();
    }

    public void SpinLeft()
    {
        //Debug.Log("spinning left");
        leftRotation.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
    }
    
    public void SpinRight()
    {
        //Debug.Log("spinning right");
        rightRotation.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
    }

    public void PlayLeft()
    {
        leftAudio.PlayOneShot(leftAudio.clip);
    }

    public void PlayRight()
    {
        rightAudio.PlayOneShot(rightAudio.clip);
    }

    public void PlayBoth()
    {
        PlayLeft();
        PlayRight();
    }

    public void MuteLeft()
    {
        leftAudio.volume = 0f;
        rightAudio.volume = 0.2f;
    }
    
    public void MuteRight()
    {
        rightAudio.volume = 0f;
        leftAudio.volume = 0.2f;
    }

    public void AudjustVolume(float percent)
    {
        //rightAudio.volume = 0.1f + percent;
        //leftAudio.volume = 0.1f - percent;
        if (percent > 0)
        {
            rightAudio.volume = 0.1f + percent;
            leftAudio.volume = 0.1f;
        }
        else if (percent < 0)
        {
            leftAudio.volume = 0.1f - percent;
            rightAudio.volume = 0.1f;
        }
    }
}
