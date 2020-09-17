using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float moveX = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Time.deltaTime * moveX;
        transform.Translate(new Vector3(moveX, 0.0f, 0.0f));
    }

   void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name
        //Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.name != "Enemy Angry")
        {
            moveX = moveX * -1;
        }
    }
}
