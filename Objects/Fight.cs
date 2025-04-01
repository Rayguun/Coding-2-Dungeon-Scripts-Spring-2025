
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;
    private Inhabitant temp;
    private bool attackerTurn;

    private Text playerHealthText;
    private Text monsterHealthText;

    private float attackCooldown = 1f;
    private float timeSinceLastAttack = 0f;

    private int armorCheck;
    private int damage;
    private bool waitingForPlayerInput = false;

    public Fight(Monster p1, Player p2, Text monsterHealthText, Text playerHealthText)
    {
        this.playerHealthText = playerHealthText;
        this.monsterHealthText = monsterHealthText;

        this.playerHealthText.text = "Player Health: " + p2.getCurrentHP();
        this.monsterHealthText.text = "Monster Health: " + p1.getCurrentHP();
        

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

    public void updateFight(GameObject playerGO, GameObject monsterGO)
    {
        timeSinceLastAttack += Time.deltaTime;

        if (timeSinceLastAttack >= attackCooldown)
        {
            timeSinceLastAttack = 0f;

            if (defender.getCurrentHP() > 0 && attacker.getCurrentHP() > 0)
            {
                if (attackerTurn)
                {
                    //Waits for player input
                    if (!waitingForPlayerInput)
                    {
                        Debug.Log("Waiting for player input...");
                        Debug.Log("Press 1 For A Normal Attack");
                        Debug.Log("Press 2 For A Heavy Attack");
                        Debug.Log("Press 3 To Drink A Health Potion");
                        waitingForPlayerInput = true;
                    }
                    else
                    {
                        checkPlayerInput(playerGO, monsterGO); 
                    }
                }
                else
                {
                    performMonsterAttack(playerGO, monsterGO);
                    attackerTurn = true; 
                }
            }
        }
    }

    private void checkPlayerInput(GameObject playerGO, GameObject monsterGO)
    {
        armorCheck = Random.Range(0, 20) + 1;
        // Detect input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Normal Attack");
            // Perform a normal attack
            if (armorCheck >= defender.getAC())
            {
                damage = Random.Range(0, 6) + 1;
                defender.takeDamage(damage);
            }
            endPlayerTurn(playerGO, monsterGO);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Perform a heavy attack
            armorCheck = Mathf.RoundToInt(armorCheck * 0.75f);
            if (armorCheck >= defender.getAC())
            {
                Debug.Log("Uses big attack");
                damage = Random.Range(0, 6) + 1;
                damage = Mathf.RoundToInt(damage * 1.50f);
                defender.takeDamage(damage);
            }
            endPlayerTurn(playerGO, monsterGO);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            
            // Use a health potion
            if (attacker.getCurrentHP() < attacker.getMaxHP())
            {
                Debug.Log("Drinks Potion");
                int potionEffect = Mathf.RoundToInt(attacker.getMaxHP() * 0.25f);
                attacker.heal(potionEffect);
            }
            else
            {
                Debug.Log("You are already at max HP");
            }
            endPlayerTurn(playerGO, monsterGO);
        }
        if (armorCheck <= defender.getAC())
        {
            Debug.Log("Player missed");
            endPlayerTurn(playerGO, monsterGO);
        }
    }


    private void performMonsterAttack(GameObject playerGO, GameObject monsterGO)
    {
        armorCheck = Random.Range(0, 20) + 1;

        // Additional attack logic for monsters
        if (armorCheck >= defender.getAC())
        {
            if (attacker is Monster)
            {
                damage = Random.Range(0, 6) + 1;
                defender.takeDamage(damage);
            }

            if (defender.getCurrentHP() <= 0)
            {
                Debug.Log("The " + attacker.getName() + " is the winner!");
                if (defender is Player)
                {
                    playerGO.SetActive(false);
                }
                if (defender is Monster)
                {
                    GameObject.Destroy(monsterGO);
                }
                return;
            }

            updateHealthTexts(attacker, defender);
            Debug.Log("The " + defender.getName() + " takes " + damage + " damage!");
            temp = attacker;
            attacker = defender;
            defender = temp;
        }
        else
        {
            Debug.Log("The " + attacker.getName() + " missed");
            temp = attacker;
            attacker = defender;
            defender = temp;
        }
    }
    //Needs work
    private void endPlayerTurn(GameObject playerGO, GameObject monsterGO)
    {
       //Stops waiting for the player
        waitingForPlayerInput = false;
        //MMonster's turn now
        attackerTurn = false; 

        if (defender.getCurrentHP() <= 0)
        {
            Debug.Log("The " + attacker.getName() + " is the winner!");
            if (defender is Player)
            {
                playerGO.SetActive(false);
            }
            else if (defender is Monster)
            {
                GameObject.Destroy(monsterGO);
            }
            return;
        }

        updateHealthTexts(attacker, defender);
        Debug.Log("Turn ended. Switching to monster's turn.");
    }

    //Updates the healthtexts every turn. 
    private void updateHealthTexts(Inhabitant attacker, Inhabitant defender)
    {
        if (defender is Player)
        {
            playerHealthText.text = defender.getName() + " Health: " + defender.getCurrentHP();
            monsterHealthText.text = attacker.getName() + " Health: " + attacker.getCurrentHP();
        }
        else
        {
            playerHealthText.text = attacker.getName() + " Health: " + attacker.getCurrentHP();
            monsterHealthText.text = defender.getName() + " Health: " + defender.getCurrentHP();
        }
    }
}







