using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarController : MonoBehaviour
{

    //private Vector3 leftMove = new Vector3(0.005f, 0.0f, 0.0f);


    public bool isPlayer;

    private Inhabitant theInhabitant;


    void Start()
    {
        if (this.isPlayer)
        {
            this.theInhabitant = Core.thePlayer;
        }
        else
        {
            this.theInhabitant = Core.theMonster;    
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float hpPercent = this.theInhabitant.getCurrentHP() / this.theInhabitant.getMaxHP();
        this.gameObject.transform.localScale = new Vector3(hpPercent, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);

    }
}
