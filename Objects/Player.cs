using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    protected string name;
    public Room currentRoom; // Stores which room the player is in. Might be usefull later

    public Player(string name)
    {

        this.name = name;

    }

    public void setCurrentRoom(Room r)
    {
        this.currentRoom = r;
    }

}
