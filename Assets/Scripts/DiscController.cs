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
        Debug.Log("spinning left");
        leftRotation.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
    }
    
    public void SpinRight()
    {
        Debug.Log("spinning right");
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
}
