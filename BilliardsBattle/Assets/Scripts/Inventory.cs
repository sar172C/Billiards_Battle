using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Inventory : MonoBehaviour
{
    public GameController controller;
    public GameObject[] itemSlotArray;
    public GameObject[] balls;
    public List<GameObject> ballsList;
    private PlayerCarry playerCarry;

    private void Start()
    {
        playerCarry = (PlayerCarry)FindObjectOfType(typeof(PlayerCarry));
        List<string> playerUnlocks = playerCarry.getPlayerUnlocks();

        foreach(string ball in playerUnlocks)
        {
            GameObject.Find(ball).tag = "Unlocked";
        }

        itemSlotArray = GameObject.FindGameObjectsWithTag("Unlocked");
        foreach (GameObject ball in itemSlotArray)
        {
            ball.transform.GetChild(1).gameObject.SetActive(true);
        }

    }
}