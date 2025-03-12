using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public GameObject[] theDoors;
    private Dungeon theDungeon;
    Room currentRoom = null;


    // Start is called before the first frame update
    void Start()
    {
        Core.thePlayer = new Player("Barbarian");
        this.theDungeon = new Dungeon();
        this.setupRoom();
        
    }

    //Turns all the doors off
    private void resetRoom()
    {
        for (int i = 0; i < theDoors.Length; i++)
        {
            theDoors[i].SetActive(false);
        }
    }

    //Shows the appropriate doors for the current room
    private void setupRoom()
    {
        Room currentRoom = Core.thePlayer.getCurrentRoom();
        this.theDoors[0].SetActive(currentRoom.hasExit("north"));
        this.theDoors[1].SetActive(currentRoom.hasExit("south"));
        this.theDoors[2].SetActive(currentRoom.hasExit("east"));
        this.theDoors[3].SetActive(currentRoom.hasExit("west"));
    }

    // Update is called once per frame
    void Update()
    {
        string direction = "";
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = "north";
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = "west";
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = "east";
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = "south";
        }
        Player thePlayer = Core.thePlayer;
        currentRoom = thePlayer.getCurrentRoom();
        for (int i = 0; i < currentRoom.currNumberOfExits; i++)
        { 
            if (thePlayer.getCurrentRoom().tryToTakeExit(direction))
            {
                //Set's room to noone in there
                currentRoom.setPlayer(null);
                //Changes the destination
                currentRoom = currentRoom.availableExits[i].getDestination();
                //Puts the player in that room
                currentRoom.setPlayer(thePlayer);
                thePlayer.setCurrentRoom(currentRoom);
                break;
            }
        }

    }

    
}
