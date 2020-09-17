using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void setChosenBall(string input)
    {
        GameObject.Find("PlayerCarry").GetComponent<PlayerCarry>().setPlayerChoice(input);
    }

    public void GoToScene(string input)
    {
        SceneManager.LoadScene(input);
    }

    public void setBall(string ball)
    {

        PlayerCarry carry = (PlayerCarry)FindObjectOfType(typeof(PlayerCarry));
        carry.GetComponent<PlayerCarry>().setPlayerChoice(ball);
    }
}
