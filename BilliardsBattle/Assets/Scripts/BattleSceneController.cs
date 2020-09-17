using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSceneController : MonoBehaviour
{
    List<Ball> balls;
    private int currentBallTurnIndex;
    bool allBallsStopped;
    private GameObject playerCarry;

    // Start is called before the first frame update
    void Start()
    {
        playerCarry = GameObject.Find("PlayerCarry");
        List<Ball> AllBalls = new List<Ball>(GameObject.FindObjectsOfType<Ball>());
        balls = new List<Ball>();

        foreach (Ball ball in AllBalls)
        {
            if(ball.tag == "Player" || ball.tag == "Enemy")
            {
                balls.Add(ball);
            }
        }
        foreach(Ball ball in balls)
        {
            if (ball.tag == "Player") currentBallTurnIndex = balls.IndexOf(ball);
            
        }

      
        allBallsStopped = true;
        balls[currentBallTurnIndex].GetComponent<Ball>().SetThisBallsTurn(true);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateAllBallsStopped();
        if (allBallsStopped)
        {
            CheckIfBattleRoundOver();
        }
        UpdateHealthOnCanvas();
    }

    void CalculateAllBallsStopped()
    {
        bool stopped = true;
        foreach (Ball b in balls)
        {
            if ((b.GetComponent<Rigidbody2D>().velocity.magnitude != 0))
            {
                stopped = false;
            }
        }
        allBallsStopped = stopped;
    }

    public void GetNextTurn()
    {
        CheckIfBattleRoundOver();
        //deactivate current balls turn
        balls[currentBallTurnIndex].GetComponent<Ball>().SetThisBallsTurn(false);
        balls[currentBallTurnIndex].GetComponent<Ball>().SetIsShooting(false);
        //get next ball
        currentBallTurnIndex = GetNextIndex();
        print("New Turn Started: " + balls[currentBallTurnIndex].tag);
        //activate next balls turn
        balls[currentBallTurnIndex].GetComponent<Ball>().SetThisBallsTurn(true);
        balls[currentBallTurnIndex].GetComponent<Ball>().SetIsShooting(true);
    }

    public bool AllBallsStopped()
    {
        return allBallsStopped;
    }

    private void UpdateHealthOnCanvas()
    {
        GameObject[] heartArray = GameObject.FindGameObjectsWithTag("HealthIndicator");
        int playerHealth = GameObject.FindObjectOfType<GameController>().GetPlayerHealth();
        if (playerHealth >= 3)
        {
            heartArray[0].GetComponent<Image>().enabled = true;
            heartArray[1].GetComponent<Image>().enabled = true;
            heartArray[2].GetComponent<Image>().enabled = true;
        }
        else if (playerHealth == 2)
        {
            heartArray[0].GetComponent<Image>().enabled = true;
            heartArray[1].GetComponent<Image>().enabled = true;
            heartArray[2].GetComponent<Image>().enabled = false;
        }
        else if (playerHealth == 1)
        {
            heartArray[0].GetComponent<Image>().enabled = true;
            heartArray[1].GetComponent<Image>().enabled = false;
            heartArray[2].GetComponent<Image>().enabled = false;
        }
        else
        {
            heartArray[0].GetComponent<Image>().enabled = false;
            heartArray[1].GetComponent<Image>().enabled = false;
            heartArray[2].GetComponent<Image>().enabled = false;
        }
    }

    private int GetNextIndex()
    {
        int index = currentBallTurnIndex;
        do
        {
            if ((index + 1) >= balls.Count)
            {
                index = 0;
            }
            else
            {
                index += 1;
            }
        } while (!balls[index].GetComponent<Ball>().IsAlive());
        
        return index;
    }

    public void CheckIfBattleRoundOver()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        bool playerBallIsAlive = (player != null);

        bool enemyBallsAreAlive = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in enemies) {
            if (e.GetComponent<Ball>().IsAlive())
            {
                enemyBallsAreAlive = true;
            }
        }
        if (!playerBallIsAlive || !enemyBallsAreAlive)
        {
            BattleRoundOver(playerBallIsAlive, enemyBallsAreAlive);
        }
    }

    public void BattleRoundOver(bool playerBallAlive, bool enemyBallsAlive)
    {
        if (playerBallAlive && !enemyBallsAlive)
        {
            //Level Won

            GameObject.FindObjectOfType<GameController>().UnlockDefeatedBall();
            if (GameObject.FindObjectOfType<GameController>().enemyBallInventory.Count == 0)
            {
                print("Beat Entire Game");
                SceneManager.LoadScene("Game Over (Won)");
            }
            else
            {
                print("Battle Level Won. Go to Inventory");
                SceneManager.LoadScene("Inventory Scene");
            }
        }
        else if (!playerBallAlive && enemyBallsAlive) {
            //Reload level if still have lives
            if (GameObject.FindObjectOfType<GameController>().GetPlayerHealth() > 0)
            {
                print("Reload Level: Player dead, Enemy Alive, player has lives");
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);

            }
            //game over if out of lives
            else
            {
                print("Game Over");
                SceneManager.LoadScene("Game Over (Lost)"); 
            }
        }
        else if (!playerBallAlive && !enemyBallsAlive)
        {
            //win level is still have lives
            if (GameObject.FindObjectOfType<GameController>().GetPlayerHealth() > 0)
            {
                print("Battle Level Won. Go to Inventory");
                SceneManager.LoadScene("Inventory Scene");
            }
            //game over if out of lives
            else
            {
                print("Game Over");
                SceneManager.LoadScene("Game Over (Lost)");
            }
        }
        else if (playerBallAlive && enemyBallsAlive)
        {
            //Do Nothing, battle still ongoing
        }
    }

}
