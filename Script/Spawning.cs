using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Spawning : MonoBehaviourPun
{
    public GameObject FootballPlayer1;
    public GameObject FootballPlayer2;
    public Transform SpawnFP1;
    public Transform SpawnFP2;

    Rigidbody2D rb;
    public Vector2 jumpForce = new Vector2(0, 200);
    //public float jumpForce = 20f;
    //float directionX;
    float waktu;
    public float timeSpan = 100;

    public GameObject kiri, kanan, jump;
    public bool jalanKiri, jalanKanan, lompat;

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waktu = timeSpan;

        if (PhotonNetwork.IsMasterClient)
        {
            SpawnPlayer1();
        }
        else
        {
            SpawnPlayer2();
        }
    }

    private void FixedUpdate()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {

        }

        if (jalanKanan)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                FootballPlayer1.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
            }
            else
            {
                FootballPlayer2.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
            }
        }

        if (jalanKiri)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                FootballPlayer1.transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
            }
            else
            {
                FootballPlayer2.transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
            }
        }

        /*if (lompat)
        {
           GetComponent<Rigidbody2D>().velocity = Vector2.zero;
           GetComponent<Rigidbody2D>().AddForce(jumpForce);
           //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
           //waktu = timeSpan;
        }
        else if (waktu > 0)
        {

        }*/
    }
    // Update is called once per frame
    public void SpawnPlayer1()
    {
        FootballPlayer1 = PhotonNetwork.Instantiate(FootballPlayer1.name, SpawnFP1.transform.position, Quaternion.identity, 0);
    }

    public void SpawnPlayer2()
    {
        FootballPlayer2 = PhotonNetwork.Instantiate(FootballPlayer2.name, SpawnFP2.transform.position, Quaternion.identity, 0);
    }

    public void OnClickKiri()
    {
        jalanKiri = true;
    }

    public void OnKiriLepas()
    {
        jalanKiri = false;
    }

    public void OnClickKanan()
    {
        jalanKanan = true;
    }

    public void OnKananLepas()
    {
        jalanKanan = false;
    }

    public void OnClickJump()
    {
        lompat = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(jumpForce);
    }

    public void OnJumpLepas()
    {
        lompat = false;
    }
}
