using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;
    private bool attackerTurn;
    private int attackRoll;

    public Fight(Monster p1, Player p2)
    {
        
        int roll = Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log("Monster goes first");
            attacker = p1;
            defender = p2;
            attackerTurn = true;
        }
        else
        {
            Debug.Log("Player goes first");
            attacker = p2;
            defender = p1;
            attackerTurn = false;
        }
        

    }

    public void startFight()
    {
        while (true)
        {
            if (attackerTurn)
            {
                attackRoll = Random.Range(0, 20) + 1;
                if (attackRoll >= 10)
                {
                    defender.takeDamage(3);
                    if (defender.getCurrentHP() <= 0)
                    {
                        Debug.Log("The " + attacker.getName() + " is the winner!");
                        break;
                    }
                    Debug.Log("The "+ defender.getName() +" takes 3 damage!");
                }
                attackerTurn = false;
            }
            else
            {
                attackRoll = Random.Range(0, 20) + 1;
                if (attackRoll >= 10)
                {
                    attacker.takeDamage(3);
                    if(attacker.getCurrentHP() <= 0)
                    {
                        Debug.Log(defender.getName() + " is the winner!");
                        break;
                    }
                    Debug.Log("The " + attacker.getName() + " takes 3 damage!");
                }
                attackerTurn = true;
            }
        }
        //should have the attacker and defender fight each until one of them dies.
        //the attacker and defender should alternate between each fight round and
        //the one who goes first was determined in the constructor.
    }

    public void damage()
    {
        
    }
}