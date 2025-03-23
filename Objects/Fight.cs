
using UnityEngine;
using UnityEngine.UI;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;
    private bool attackerTurn;

    private Text playerHealthText;
    private Text monsterHealthText;

    private float attackCooldown = 1f;
    private float timeSinceLastAttack = 0f;

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

    public void UpdateFight(GameObject playerGO, GameObject monsterGO)
    {
        timeSinceLastAttack += Time.deltaTime;

        if (timeSinceLastAttack >= attackCooldown)
        {
            timeSinceLastAttack = 0f;
            if (defender.getCurrentHP() > 0 && attacker.getCurrentHP() > 0)
            {
                if (attackerTurn)
                {
                    PerformAttack(playerGO, monsterGO);
                    attackerTurn = false;
                }
                else
                {
                    PerformAttack(playerGO, monsterGO);
                    attackerTurn = true;
                }
            }
        }
    }

    private void PerformAttack(GameObject playerGO, GameObject monsterGO)
    {
        int attackRoll = Random.Range(0, 20) + 1;

        if (attackRoll >= 10)
        {
            defender.takeDamage(3);
            UpdateHealthTexts();

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
            Debug.Log("The " + defender.getName() + " takes 3 damage!");
        }
        else
        {
            attackRoll = Random.Range(0, 20) + 1;
            if (attackRoll >= 10)
            {
                attacker.takeDamage(3);
                UpdateHealthTexts();
                if (attacker.getCurrentHP() <= 0)
                {
                    Debug.Log(defender.getName() + " is the winner!");
                    if (attacker is Player)
                    {
                        playerGO.SetActive(false);
                    }
                    if (attacker is Monster)
                    {
                        GameObject.Destroy(monsterGO);
                    }
                }
                Debug.Log("The " + attacker.getName() + " takes 3 damage!");
            }
        }
    }

    private void UpdateHealthTexts()
    {
        playerHealthText.text = "Player Health: " + Core.thePlayer.getCurrentHP();
        monsterHealthText.text = "Monster Health: " + attacker.getCurrentHP();
    }
}
