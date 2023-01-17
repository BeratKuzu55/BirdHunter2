using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi_sc : MonoBehaviour
{
    public GameObject mermi_clone , kus , clone_kus;
    public GameObject silah;
    public float timer = 0.0f;
    public int seconds;
    public int mermi_id;
    public bool is_there_any_enemy;
    public int enemy_count;
    GameObject player;
    playerMove player_script;
    void Start()
    {
        is_there_any_enemy = false;
        enemy_count = 0;
        player = GameObject.Find("player");

    }

    void Update()
    {
        player_script = player.GetComponent<playerMove>();
        transform.position += transform.rotation * new Vector3(15, 0, 0) * Time.deltaTime;
        timer += Time.deltaTime;  
        seconds = (int)(timer % 60);  // turn seconds in float to int
        if (seconds > 1)
        {
            if(mermi_id != 1)
            {
                Destroy(gameObject);           
            }
        }

    }


    float enemy_create_position_y;

    public void createEnemy(bool dusman_var_mý)
    {
        enemy_create_position_y = Random.Range(-2.5f, 2.0f);
        Vector3 enemy_create_position = new Vector3(70.0f, Random.RandomRange(2.5f ,4f), 0.0f);

        if (!dusman_var_mý)
        {
            clone_kus = Instantiate(kus, enemy_create_position, Quaternion.identity);
            enemy_count++;
            is_there_any_enemy = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag.Equals("enemy"))
        {
            player_script.score += 6;
            if (enemy_count < 1)
            {
                createEnemy(is_there_any_enemy);
            }
            Destroy(collision.gameObject);
        }
    }
}
