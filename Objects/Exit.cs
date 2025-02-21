using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit 
{
    private string direction;
    Room destiation;

    public Exit(string direction, Room destination)
    {
        this.direction = direction;
        this.destiation = destination; 

    }


}
