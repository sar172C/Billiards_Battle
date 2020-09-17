using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float directionArrowSpinSpeed = 50;
    [SerializeField] float powerSelectionSpeed = 1;
    [SerializeField] float maxPower = 100;
    private int shotPhase;
    private Vector2 directionSelected;
    private bool directionIsSelected;
    private float percentOfPowerSelected;
    private bool percentOfPowerIsSelected;
    
    // Start is called before the first frame update
    void Start()
    {
        ResetShotValues();
    }

    // Update is called once per frame
    void Update()
    {
        //if this balls turn
        if (this.GetComponent<Ball>().IsThisBallsTurn())
        {
            if (shotPhase == 0)
            {
                this.GetComponent<Ball>().SetIsShooting(true);
                StartCoroutine(SelectShotDirection());
            }
            if (shotPhase == 1)
            {
                StartCoroutine(SelectShotPower());
            }
            if (shotPhase == 2)
            {
                this.GetComponent<Ball>().SetIsShooting(false);
                if (GameObject.FindObjectOfType<BattleSceneController>().AllBallsStopped())
                {
                    shotPhase = 3;
                    GameObject.FindObjectOfType<BattleSceneController>().GetNextTurn();

                }
            }

        }
        if (!this.GetComponent<Ball>().IsThisBallsTurn())
        {
            StartCoroutine(ResetShotValues());
        }
    }

    IEnumerator SelectShotDirection()
    {
        //Determine Direction

        if (directionIsSelected)
        {
            yield return new WaitForSeconds(0);
            shotPhase = 1;
        }
        else
        {
            /** TODO: SHOOT IN DIRECTION OF PLAYER INSTEAD OF RANDOM
            List<Ball> targetList = new List<Ball>(GameObject.FindObjectsOfType<Ball>());
            targetList.Remove(this.GetComponent<Ball>());
            Ball target = targetList[Random.Range(0, targetList.Count)];
            */
            directionSelected = Random.insideUnitCircle.normalized;
            directionIsSelected = true;
            print("Enemy Direction: " + directionSelected);
        }


    }

    IEnumerator SelectShotPower()
    {
        if (percentOfPowerIsSelected)
        {
            //Shooting
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(directionSelected * (percentOfPowerSelected * maxPower), ForceMode2D.Impulse);
            percentOfPowerSelected = 0.00f;
            yield return new WaitForSeconds(1);
            shotPhase = 2;
        }
        else
        {
            //Determine Power
            percentOfPowerSelected = Random.Range(0.01f, 1f);
            percentOfPowerIsSelected = true;
            print("Enemy Percent Power: " + percentOfPowerSelected);
        }

    }


    private IEnumerator ResetShotValues()
    {
        shotPhase = 0;
        directionSelected = new Vector2(1, 1);
        directionIsSelected = false;
        percentOfPowerSelected = 0.00f;
        percentOfPowerIsSelected = false;
        yield return new WaitForSeconds(0);
    }
}
