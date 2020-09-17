using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int playerHealth;

    [SerializeField] GameObject billiardBall0 = null;
    [SerializeField] GameObject billiardBall1 = null;
    [SerializeField] GameObject billiardBall2 = null;
    [SerializeField] GameObject billiardBall3 = null;
    [SerializeField] GameObject billiardBall4 = null;
    [SerializeField] GameObject billiardBall5 = null;
    [SerializeField] GameObject billiardBall6 = null;
    [SerializeField] GameObject billiardBall7 = null;
    [SerializeField] GameObject billiardBall8 = null;
    [SerializeField] GameObject billiardBall9 = null;
   
    public List<GameObject> playerBallInventory;
    public List<GameObject> enemyBallInventory;
    public GameObject playerSelectedBall;
    public GameObject enemySelectedBall;
    public GameObject spawner;
    public GameObject playerCarry;

   // private static GameController ControllerInstance;
  /*  private void Awake()
    {
        if (ControllerInstance == null)
        {
            DontDestroyOnLoad(this);
            ControllerInstance = this;
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        playerCarry = GameObject.Find("PlayerCarry");
        //add player starting ball
        spawner = GameObject.Find("Battle Scene Controller");
        playerBallInventory = new List<GameObject>();

        if(GameObject.Find(playerCarry.GetComponent<PlayerCarry>().getPlayerChoice()) != null)
        playerSelectedBall = GameObject.Find(playerCarry.GetComponent<PlayerCarry>().getPlayerChoice());
        playerBallInventory.Add(playerSelectedBall);
        playerCarry.tag = "CorrectCarry";
        Debug.Log(GameObject.Find(playerCarry.GetComponent<PlayerCarry>().getPlayerChoice()));

        //add all other balls
        enemyBallInventory = new List<GameObject>();
        enemyBallInventory.Add(billiardBall1);
        enemyBallInventory.Add(billiardBall2);
        enemyBallInventory.Add(billiardBall3);
        enemyBallInventory.Add(billiardBall4);
        enemyBallInventory.Add(billiardBall5);
        enemyBallInventory.Add(billiardBall6);
        enemyBallInventory.Add(billiardBall7);
        enemyBallInventory.Add(billiardBall8);
        enemyBallInventory.Add(billiardBall9);

        if(enemySelectedBall == null)
        enemySelectedBall = RandomEnemyBall();

        if(playerSelectedBall != null)
        {
            playerSelectedBall.tag = "Player";
        }
        if(enemySelectedBall != null)
        {
            enemySelectedBall.tag = "Enemy";
        }
      //  playerSelectedBall.name = "Player";
      //  enemySelectedBall.name = "Enemy";

        //Debug.Log("Scene Reloadawfnoaiwfnaesueion");
       // if(ControllerInstance == null)
        //DontDestroyOnLoad(enemySelectedBall.gameObject);
        if (playerSelectedBall != null && enemySelectedBall != null)
        {
            spawner.GetComponent<Spawning>().spawnBalls(playerSelectedBall, enemySelectedBall);
        }
    }


    public int GetPlayerHealth()
    {
        return this.playerHealth;
    }

    public void DecreasePlayerHealth()
    {
        this.playerHealth -= 1;
        print("Lost Health. Current Health: " + playerHealth);
    }

    public void IncreasePlayerHealth()
    {
        this.playerHealth += 1;
        print("Gained Health. Current Health: " + playerHealth);
    }

    private GameObject RandomEnemyBall()
    {
        int index = Random.Range(0, enemyBallInventory.Count);
        return enemyBallInventory[index];
    }

    public void UnlockDefeatedBall()
    {
        Debug.Log("enemy unlocked: " + enemySelectedBall.name);
        playerCarry.GetComponent<PlayerCarry>().setPlayerUnlock(enemySelectedBall.name);

        playerBallInventory.Add(enemySelectedBall);
        enemyBallInventory.Remove(enemySelectedBall);
        this.enemySelectedBall = RandomEnemyBall();
    }
}
