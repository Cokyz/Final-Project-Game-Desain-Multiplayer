using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bOL : MonoBehaviour
{
    Rigidbody2D rb;
    public int force;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }

        if(collision.gameObject.tag == "ScoreP1")
        {
            manager.AddScoreP1();
            gameObject.transform.position = new Vector2(-6, 5);
        }

        if (collision.gameObject.tag == "ScoreP2")
        {
            manager.AddScoreP2();
            gameObject.transform.position = new Vector2(-20, 5);
        }
    }
}
