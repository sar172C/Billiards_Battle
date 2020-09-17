using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Increase Player Health
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GetPlayerHealth() < 3)
            {
                print("Played Heart Pickup Sound");
                GetComponent<AudioSource>().Play();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().IncreasePlayerHealth();
                this.gameObject.GetComponent<Renderer>().enabled = false;
                this.gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
