using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    bool isThisBallsTurn = false;
    bool isAlive = true;
    bool isShooting = false;
    private AudioSource ballCollisionSound = null;
    private AudioSource wallCollisionSound = null;


    private void Start()
    {
        AudioSource[] sounds = GetComponents<AudioSource>();
        ballCollisionSound = sounds[0];
        wallCollisionSound = sounds[1];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            print("Played Ball Collision Sound");
            ballCollisionSound.Play();
        }
        if (collision.gameObject.tag == "Wall")
        {
            print("Played Wall Collision Sound");
            wallCollisionSound.Play();
        }

    }

    public void SetThisBallsTurn(bool ballsTurn)
    {
        this.isThisBallsTurn = ballsTurn;
    }

    public bool IsThisBallsTurn()
    {
        return isThisBallsTurn;
    }

    public void SetIsAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }

    public bool IsAlive()
    {
        return this.isAlive;
    }


    public void SetIsShooting(bool isShooting)
    {
        this.isShooting = isShooting;
    }

    public bool IsShooting()
    {
        return this.isShooting;
    }


}
