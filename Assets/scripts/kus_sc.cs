using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kus_sc : MonoBehaviour
{
    float random_float;
    float random_enemy_velocity;
    int score;
    public GameObject bomb;
    bool dead=false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        random_enemy_velocity = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject != null)
        {
            transform.position += new Vector3(-Random.Range(0.1f , 0.4f), 0, 0); // unity deki random range degerleri 0.03 0.08
            SpawnRotouine();
        }
        if (transform.position.x < -80.0f)
        {
            Instantiate(this.gameObject, new Vector3(50f, 3f, 0f), Quaternion.identity);
            Destroy(this.gameObject);
            dead = true;
        }
    }
    float time = 1.0f;
    void SpawnRotouine()
    {
        time -= Time.deltaTime;
        if(( transform.position.x- GameObject.Find("player").transform.position.x < 10f && transform.position.x - GameObject.Find("player").transform.position.x > -10f) && SceneManager.GetActiveScene().name=="SampleScene")
        {
            if (time < 0 && !dead)
            {
                //print(transform.position);
                Instantiate(bomb, new Vector3(transform.position.x , transform.position.y , 0f), Quaternion.identity);
                time = 1.0f;
            }
        }
        if (( transform.position.x - GameObject.Find("player").transform.position.x < 10f && transform.position.x - GameObject.Find("player").transform.position.x > -10f) && SceneManager.GetActiveScene().name == "bolum2")
        {
            if (time < 0 && !dead)
            {
                //print(transform.position);
                Instantiate(bomb, new Vector3(transform.position.x , transform.position.y , 0f), Quaternion.identity);
                time = 1.0f;
            }
        }
    }
}
