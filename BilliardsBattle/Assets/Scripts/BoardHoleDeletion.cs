using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoardHoleDeletion : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        //if collision is a ball
        if (col.gameObject.GetComponent<Ball>() != null)
        {
            //set ball to be dead
            col.gameObject.GetComponent<Ball>().SetIsAlive(false);
            //remove health if its the player
            if (col.gameObject.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().DecreasePlayerHealth();
            }
            //destroy ball
            col.gameObject.SetActive(false);
        }
    }
}
