using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooter : MonoBehaviour
{

    [SerializeField] float directionArrowSpinSpeed = 50;
    [SerializeField] float powerSelectionSpeed = 1;
    [SerializeField] float maxPower = 100;
    [SerializeField] GameObject directionArrowPrefab = null;
    [SerializeField] Slider newPowerBarPrefab;
    private int shotPhase = 0;
    GameObject directionArrow = null;
    private Vector2 directionSelected = new Vector2(0,0);
    private float percentOfPowerSelected = 0.01f;
    GameObject powerbar;

    // Start is called before the first frame update
    void Start()
    {
        powerbar = GameObject.Find("PowerBar");
        ResetShotValues();
    }

    // Update is called once per frame
    void Update()
    {
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

    public IEnumerator SelectShotDirection()
    {
        if (directionArrow == null)
        {
            //create arrow object
            directionArrow = Instantiate(directionArrowPrefab);
            directionArrow.transform.position = this.transform.position;
        }

        //rotate arrow object until space pressed
        directionArrow.transform.Rotate(Vector3.forward * (directionArrowSpinSpeed * Time.deltaTime));
        directionArrow.transform.position = this.transform.position;

        //wait for player input
        if (Input.GetKeyDown("space"))
        {
            //get spin angle
            var xDirection = Mathf.Cos(directionArrow.transform.localEulerAngles.z * (Mathf.PI / 180));
            var yDirection = Mathf.Sin(directionArrow.transform.localEulerAngles.z * (Mathf.PI / 180));
            directionSelected = new Vector2(xDirection, yDirection);
            print("Player Direction: " + directionSelected);
            yield return new WaitForSeconds(0);
            //shot direction is selected
            Destroy(directionArrow);
            shotPhase = 1;
            directionArrow = null;

        }
    }

    public IEnumerator SelectShotPower()
    {

        powerbar.GetComponent<PowerBarScript>().movement();

        if (Input.GetKeyDown("space"))
        {
            //shot power is selected
            //move ball
            print("Player Percent Power: " + percentOfPowerSelected);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(directionSelected * (percentOfPowerSelected * maxPower), ForceMode2D.Impulse);
            yield return new WaitForSeconds(1);
            shotPhase = 2;
        }
        else
        {
            //fluxuate percent of power between 0 and 1 
            percentOfPowerSelected = Mathf.PingPong(Time.time, 1);
        }
    }

    private IEnumerator ResetShotValues()
    {
        shotPhase = 0;
        directionArrow = null;
        directionSelected = new Vector2(1,1);
        percentOfPowerSelected = 0.01f;
        yield return new WaitForSeconds(0);
    }
}
