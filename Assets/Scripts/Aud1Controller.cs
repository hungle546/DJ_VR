using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aud1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject audOriginal;
    public GameObject audCount;

    void Start()
    {
        CreateAud(5);
    }

    private void CreateAud(int audNum)
    {
        for (int i = 0; i < audNum; i++)
        {
            // GameObject CoinClone = Instantiate(coinOriginal);
            GameObject audClone = Instantiate(audOriginal, new Vector3(i * 0.6f, audOriginal.transform.position.y, i * 0.75f), audOriginal.transform.rotation);
            audClone.name = "CoinClone-" + (i + 1);
            audClone.transform.parent = audCount.transform;
        }
    }
}
