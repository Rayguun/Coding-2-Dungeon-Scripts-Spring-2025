using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon 
{
    
    public Dungeon()
    {

        Room r1 = new Room("R1");
        Room r2 = new Room("R2");
        Room r3 = new Room("R3");
        Room r4 = new Room("R4");
        Room r5 = new Room("R5");
        Room r6 = new Room("R6");

        r1.addExit("North", r2);
        r2.addExit("South", r1);
        r2.addExit("North", r3);
        r3.addExit("North", r6);
        r3.addExit("East", r5);
        r3.addExit("South", r2);
        r3.addExit("West", r4);
        r4.addExit("East", r3);
        r5.addExit("West", r3);
        r6.addExit("South", r3);
    }
}
