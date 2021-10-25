using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject aud1;
    private Vector3 quadrant1;
    private Vector3 quadrant2;
    private Vector3[] quadrants = new Vector3[2]; 

    void Start()
    {
        CreateAud();
    }

    private void CreateAud()
    {
        quadrants[0] = new Vector3(Random.Range(2, 100), .6f, Random.Range(2, 100)); 
        quadrants[1] = new Vector3(Random.Range(100,200), .6f, Random.Range(2, 100)); 
        quadrants[2] = new Vector3(Random.Range(2, 100), .6f, Random.Range(100, 200));
        Instantiate(aud1, quadrants[0], aud1.transform.rotation); 
        Instantiate(aud1, quadrants[1], aud1.transform.rotation); 
        Instantiate(aud1, quadrants[2], aud1.transform.rotation); 
    }
}
