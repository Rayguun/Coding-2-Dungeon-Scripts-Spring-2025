using UnityEngine;
using UnityEngine.UI;

public class fightSceneManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Monster;

    public Text PlayerHealthText;
    public Text MonsterHealthText;

    private Fight fight;

    void Start()
    {
        Monster theMonster = new Monster("Goblin");
        fight = new Fight(theMonster, Core.thePlayer, MonsterHealthText, PlayerHealthText);
    }

    void Update()
    {
        fight.UpdateFight(Player, Monster);
    }
}
    