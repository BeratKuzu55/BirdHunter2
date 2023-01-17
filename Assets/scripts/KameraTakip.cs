using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{

    public GameObject hedefObje;
    public Vector3 kamera_uzakligi;  //offset
    public Vector3 hedef_pozisyon;
    private Vector3 velocity = Vector3.zero;
    public float yumusaklik_degeri = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        hedefObje = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        hedef_pozisyon = hedefObje.transform.position + kamera_uzakligi;
        hedef_pozisyon.y += 2.0f;
        transform.position = Vector3.SmoothDamp(transform.position, hedef_pozisyon, ref velocity, yumusaklik_degeri);
    }

}
