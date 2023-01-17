using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 a;
    Rigidbody2D rb;
    GameObject player;
    playerMove player_script;
    float eklenecek_puan;
    int top_score;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        top_score = PlayerPrefs.GetInt("topScore");
    }
    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player");
        player_script = player.GetComponent<playerMove>();
        
        //transform.rotation *= Quaternion.Euler(GameObject.Find("player").transform.position);
        rb.AddForce((GameObject.Find("player").transform.position - transform.position) * 0.7f);  //ilk deger *0.1;
        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // eklenecek_puan = player_script.gecen_zaman;
        if (collision.gameObject.tag == "ground")
        {
            player_script.score++;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Destroy(GameObject.Find("audioObject"));
        }
    }
}