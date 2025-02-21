using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public GameObject[] theDoors;
    private Dungeon theDungeon;

    // Start is called before the first frame update
    void Start()
    {
        Core.thePlayer = new Player("Barbarian");
        this.theDungeon = new Dungeon();

        this.theDoors[0].SetActive(Core.westDoor);
        this.theDoors[1].SetActive(Core.eastDoor);
        this.theDoors[2].SetActive(Core.northDoor);
        this.theDoors[3].SetActive(Core.southDoor);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
