using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject aud1;
    [SerializeField] private GameObject aud2;
    [SerializeField] private GameObject aud3;
    // test 1
    private Vector3 quadrant1;
    private Vector3 quadrant2;
    private Vector3[] quadrants = new Vector3[3]; 
    private Animator ac;
    private GameObject[] garray;
    private GameObject[] garray1;
    private GameObject[] garray2; 
    
    void Start()
    {
        CreateAud();
    }

    private void CreateAud()
    {
        randomLoc();
        Debug.Log("sup!");

        for (int i = 0; i < 100; i++)
        {
            randomLoc();
            Instantiate(aud1, quadrants[i%3], aud1.transform.rotation); 
        }
        
        for (int i = 0; i < 100; i++)
        {
            randomLoc();
            Instantiate(aud2, quadrants[i%3], aud2.transform.rotation);
        }
        for (int i = 0; i < 100; i++)
        {
            randomLoc();
            Instantiate(aud3, quadrants[i%3], aud3.transform.rotation);
        }
    }

    public void ButtonPlayed()
    {
        garray = GameObject.FindGameObjectsWithTag("AUD1");
        garray1 = GameObject.FindGameObjectsWithTag("AUD2");
        garray2 = GameObject.FindGameObjectsWithTag("AUD3");
        
        foreach (var go in garray)
        {
            Animator temp;
            temp = go.GetComponent<Animator>();
            temp.SetBool("isIdle", false);
            temp.SetBool("isDance", true);
        }
        foreach (var go1 in garray1)
        {
            Animator temp1;
            temp1 = go1.GetComponent<Animator>();
            temp1.SetBool("isIdle", false);
            temp1.SetBool("isDance1", true);
        }
        foreach (var go2 in garray2)
        {
            Animator temp2;
            temp2 = go2.GetComponent<Animator>();
            temp2.SetBool("isIdle", false);
            temp2.SetBool("isDance2", true);
        }
    }

    public void MusicOff()
    {
        garray = GameObject.FindGameObjectsWithTag("AUD1");
        garray1 = GameObject.FindGameObjectsWithTag("AUD2");
        garray2 = GameObject.FindGameObjectsWithTag("AUD3");
        foreach (var go in garray)
        {
            Animator temp;
            temp = go.GetComponent<Animator>();
            temp.SetBool("isIdle", true);
            temp.SetBool("isDance", false);
        }
        foreach (var go1 in garray1)
        {
            Animator temp1;
            temp1 = go1.GetComponent<Animator>();
            temp1.SetBool("isIdle", true);
            temp1.SetBool("isDance1", false);
        }
        foreach (var go2 in garray2)
        {
            Animator temp2;
            temp2 = go2.GetComponent<Animator>();
            temp2.SetBool("isIdle", true);
            temp2.SetBool("isDance2", false);
        }
    }

    private void randomLoc()
    {
        quadrants[0] = new Vector3(Random.Range(-2, 4), 0f, Random.Range(0, 60)); 
        quadrants[1] = new Vector3(Random.Range(-10, 10), 0f, Random.Range(10, 60)); 
        quadrants[2] = new Vector3(Random.Range(-7, 7), 0f, Random.Range(5, 60));
    }
}
