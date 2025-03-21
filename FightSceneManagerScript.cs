using System;
using UnityEngine;

public class fightSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Monster theMonster = new Monster("Goblin");
        Fight f = new Fight(theMonster, Core.thePlayer);
        f.startFight();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
