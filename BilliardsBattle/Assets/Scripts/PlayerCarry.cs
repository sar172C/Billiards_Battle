using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    [SerializeField] public string playerChoice;
    private string playerUnlock;
    private List<string> playerUnlocks = new List<string>();

    private static PlayerCarry CarryInstance;
     private void Awake()
      {
          if (CarryInstance == null)
          {
              DontDestroyOnLoad(this);
              CarryInstance = this;
          }
          else
        {
            if(CarryInstance != this)
            {
                Destroy(gameObject);
            }
        }
      }

    private void Start()
    {
        if (this.tag != "CorrectCarry" && playerUnlock != null) Destroy(this);
    }

    public string getPlayerChoice()
    {
        return playerChoice;
    }

    public List<string> getPlayerUnlocks()
    {
        return playerUnlocks;
    }

    public void setPlayerUnlock(string playerUnlock)
    {

        this.playerUnlocks.Add(playerUnlock);
    }

    public void setPlayerChoice(string playerChoice1)
    {
       
        this.playerChoice = playerChoice1;
    }
}
