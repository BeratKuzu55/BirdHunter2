using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puan_sc : MonoBehaviour
{
    public int puan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);   
    }
}
