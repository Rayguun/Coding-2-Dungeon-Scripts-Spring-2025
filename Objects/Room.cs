using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    private Player thePlayer;

    private GameObject[] theDoors;
    public Exit[] availableExits = new Exit[4];
    public int currNumberOfExits = 0;
    

    private string name;

    public Room(string name)
    {
        this.name = name;
        this.thePlayer = null;
    }

    public void setPlayer(Player p)
    {
        this.thePlayer = p;
        this.thePlayer.setCurrentRoom(this);
    }

    public string getName()
    {
        return this.name;
    }

    public bool tryToTakeExit(string direction)
    {
        if (this.hasExit(direction))
        {
            return true;
        }
        else
        {
            Debug.Log("No exit in this direction");
        }
        return false;

    }
    public bool hasExit(string direction)
    {
        for (int i = 0; i < this.currNumberOfExits; i++)
        {
            if (string.Equals(this.availableExits[i].getDirection(), direction))
            {
                return true;
            }
        }
            return false;
    }


    public void addExit(string direction, Room destination)
    {
        if (this.currNumberOfExits <= 3)
        {
            Exit e = new Exit(direction, destination);
            this.availableExits[this.currNumberOfExits] = e;
            this.currNumberOfExits++;
        }
    }

}

