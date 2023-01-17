using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ak47_sc : MonoBehaviour
{
    public float mouse_hareketi;
    public GameObject mermi;
    public GameObject clone_mermi;
    public GameObject silah_ucu;
    public GameObject silah_ortasi;
    public GameObject silah_tutma_pozisyonu2;
    public Vector3 silah_rotasyon, silah_ucu_pozisyon, silah_pozisyon , silah_yonu;
    public int mermi_id;
    mermi_sc mermi_script;
    AudioSource audioSource;
    GameObject player;
    playerMove player_script;
    void Start()
    {
        silah_yonu = new Vector3(0.0f, 0.0f, 12.0f);
        silah_ucu = transform.Find("silahUcu").gameObject;
        silah_ucu_pozisyon = new Vector3(0, 0, 0);
        silah_pozisyon = new Vector3(0, 0, 0);
        mermi_id = 0;
        
        mermi_script = mermi.GetComponent<mermi_sc>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0.25f;

    }

    // Update is called once per frame

    bool kontrol = false;
    void Update()
    {
        player = GameObject.Find("player");
        player_script = player.GetComponent<playerMove>();
        silah_ucu_pozisyon = silah_ucu.transform.position;
        silah_pozisyon = transform.position;

        if (transform.parent != null)
        {
           

                mouse_hareketi = Input.GetAxis("Mouse Y");
                silah_rotasyon = mouse_hareketi * silah_yonu;
    
                if (mouse_hareketi < 0 && transform.localRotation.z >= -0.10f)
                {
                    transform.rotation *= Quaternion.Euler(silah_rotasyon);
                }
                else if (mouse_hareketi > 0 && transform.localRotation.z <= 0.45)
                {
                    transform.rotation *= Quaternion.Euler(silah_rotasyon);
                }

            

            Vector3 mermi_olusma_pozisyonu = new Vector3(silah_ucu.transform.position.x, silah_ucu.transform.position.y, transform.position.z);
            if (Input.GetButtonDown("Fire1"))
            {
                player_script.score--;
                kontrol = true;
                clone_mermi = Instantiate(mermi, mermi_olusma_pozisyonu, Quaternion.identity);
                clone_mermi.transform.rotation *= gameObject.transform.rotation;
                mermi_id++;
                //print(mermi_id + "in ak47 script");
                mermi_script.mermi_id = mermi_id;
                audioSource.Play();
            }
             
            if (kontrol)  
            {
                if(clone_mermi != null)
                {
                    clone_mermi.transform.position += clone_mermi.transform.rotation * new Vector3(15, 0, 0) * Time.deltaTime;
                }
         
            }
            

        }
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Vector3 silah_tutma_pozisyonu_son = new Vector3(0, 0, 0);
            silah_tutma_pozisyonu_son.y = silah_tutma_pozisyonu2.transform.position.y - 0.18f;
            if (collision.gameObject.transform.rotation.y != 0)
            {
                gameObject.transform.rotation *= Quaternion.Euler(0, -180, 0); 
                silah_tutma_pozisyonu_son.x = silah_tutma_pozisyonu2.transform.position.x - 0.2f;
                gameObject.transform.position = silah_tutma_pozisyonu_son;
                gameObject.transform.SetParent(collision.gameObject.transform);

            }
            else
            {
                gameObject.transform.position = silah_tutma_pozisyonu_son;
                silah_tutma_pozisyonu_son.x = silah_tutma_pozisyonu2.transform.position.x + 0.2f;
                gameObject.transform.position = silah_tutma_pozisyonu_son;
                gameObject.transform.SetParent(collision.gameObject.transform);
                // 2. parametreyi true yaparsak pleyer silaha nereden dokunursa o þekilde kalýr
            }


        }
    }


}
