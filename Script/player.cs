using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class player : MonoBehaviourPun
{
    //public float jumpforce = 20f;
    //float directionX;
    public float speed;
    public Vector2 jumpForce = new Vector2(0, 200);
    float waktu;
    public float timeSpan = 100;
    Rigidbody2D rb;
    bool kanan, kiri;


    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D> ();
       waktu = timeSpan;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
        }*/
    }

    void FixedUpdate()
    {
        //Debug.Log(waktu);
        waktu = waktu - Time.deltaTime;

        if (kiri == true)
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
        }

        if (kanan == true)
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }

    }

    public void bolKiri()
    {
        kiri = true;
    }
    public void bolKiriFalse()
    {
        kiri = false;
    }

    public void bolKanan()
    {
        kanan = true;
    }
    public void bolKananFalse()
    {
        kanan = false;
    }

    public void Jump()
    {
        if (waktu < 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
            waktu = timeSpan;
        }
        else if (waktu > 0)
        {

        }
    }

    /*public void lompat()
    {
        // if (waktu < 0)
        // {
        //  GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //GetComponent<Transform>().AddForce(jumpForce);
        //transform.Translat(new Vector3 (0, -1)*Time.deltaTime*3);    
        rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Force);
        //waktu = timeSpan;
        // }
        // else if (waktu > 0)
        // {

        // }
    }*/

}
