using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject aud1;
    private Vector3 quadrant1;
    private Vector3 quadrant2;
    private Vector3[] quadrants = new Vector3[3]; 
    private Animator ac;
    private GameObject[] garray;
    void Start()
    {
        CreateAud();
    }

    private void CreateAud()
    {
        quadrants[0] = new Vector3(Random.Range(-20, 20), 0f, Random.Range(0, 25)); 
        quadrants[1] = new Vector3(Random.Range(-20, 20), 0f, Random.Range(0, 25)); 
        quadrants[2] = new Vector3(Random.Range(-20, 20), 0f, Random.Range(0, 25));
        Debug.Log("sup!");
        Instantiate(aud1, quadrants[0], aud1.transform.rotation); 
        Instantiate(aud1, quadrants[1], aud1.transform.rotation); 
        Instantiate(aud1, quadrants[2], aud1.transform.rotation);
    }

    public void ButtonPlayed()
    {
        garray = GameObject.FindGameObjectsWithTag("AUD1");
        foreach (var go in garray)
        {
            Animator temp;
            temp = go.GetComponent<Animator>();
            temp.SetBool("isIdle", false);
            temp.SetBool("isDance", true);
        }
    }

    public void MusicOff()
    {
        garray = GameObject.FindGameObjectsWithTag("AUD1");
        foreach (var go in garray)
        {
            Animator temp;
            temp = go.GetComponent<Animator>();
            temp.SetBool("isIdle", true);
            temp.SetBool("isDance", false);
        }
    }
}
