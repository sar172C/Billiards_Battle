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
        playerCarry = GameObject.Find("PlayerCarry").GetComponent<PlayerCarry>();

        if (playerCarry.getPlayerUnlock() != null)
        {
            Debug.Log(playerCarry.getPlayerUnlock());
            GameObject.Find(playerCarry.getPlayerUnlock()).tag = "Unlocked";
        }

        itemSlotArray = GameObject.FindGameObjectsWithTag("Unlocked");
        foreach(GameObject ball in itemSlotArray)
        {
            ball.transform.GetChild(1).gameObject.SetActive(true);
        }

    }
     /*   ballsList = controller.playerBallInventory;
        int i = 0;
        for (i=0;i<ballsList.Capacity; i++)
        {
            Debug.Log(i+1);
        }

        itemSlotArray = GameObject.FindGameObjectsWithTag("ItemSlot");
        
        for (i = 0; i < itemSlotArray.Length; i++) {
            int X = Int32.Parse(itemSlotArray[i].name.Substring(8));

            for (int j = 0; j < ballsList.Capacity; i++)
            {
                int Y = Int32.Parse(controller.playerBallInventory[i].name.Substring(12));
                if (X == Y)
                {
                    itemSlotArray[i].transform.GetChild(1).gameObject.SetActive(true);
                  //  GameObject.Find(PlayerCarry).GetComponent<PlayerCarry>().setPlayerChoice(controller.playerBallInventory)
                }
            }
        }
    }*/
}


//comments below are concepts for how to read player inventory
/*

ItemSlotArray = GameObject.FindGameObjectsWithTag("Item Slot");

    for(int i=0; i < playerBallInventory.length; i++){

        //parse inventory item string name, pull out number (definitely not correct but you get the idea) (13th character)
        int X = StringToInt(playerBallInventory[i].name.lastNumber);

        ItemSlotArray[X].GetChild(1).SetActive(true);
    }

*/
