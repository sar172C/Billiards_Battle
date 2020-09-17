using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int playerHealth;

    [SerializeField] GameObject billiardBall0;
    [SerializeField] GameObject billiardBall1;
    [SerializeField] GameObject billiardBall2;
    [SerializeField] GameObject billiardBall3;
    [SerializeField] GameObject billiardBall4;
    [SerializeField] GameObject billiardBall5;
    [SerializeField] GameObject billiardBall6;
    [SerializeField] GameObject billiardBall7;
    [SerializeField] GameObject billiardBall8;
    [SerializeField] GameObject billiardBall9;
   
    public List<GameObject> playerBallInventory;
    public List<GameObject> enemyBallInventory;
    public GameObject playerSelectedBall;
    public GameObject enemySelectedBall;
    public GameObject spawner;

    private static GameController ControllerInstance;
    private void Awake()
    {
        if (ControllerInstance == null)
        {
            DontDestroyOnLoad(this);
            ControllerInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //add player starting ball
        spawner = GameObject.Find("Battle Scene Controller");
        playerBallInventory = new List<GameObject>();
        playerBallInventory.Add(billiardBall0);
        playerSelectedBall = billiardBall0;

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

        playerSelectedBall.tag = "Player";
        enemySelectedBall.tag = "Enemy";
        playerSelectedBall.name = "Player";
        enemySelectedBall.name = "Enemy";

        Debug.Log("Scene Reloadawfnoaiwfnaesueion");
        if(ControllerInstance == null)
        DontDestroyOnLoad(enemySelectedBall.gameObject);
        spawner.GetComponent<Spawning>().spawnBalls(playerSelectedBall, enemySelectedBall);
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
        playerBallInventory.Add(enemySelectedBall);
        enemyBallInventory.Remove(enemySelectedBall);
        this.enemySelectedBall = RandomEnemyBall();
    }
}
