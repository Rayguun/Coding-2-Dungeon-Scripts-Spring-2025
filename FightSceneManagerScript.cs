using UnityEngine;
using UnityEngine.UI;

public class fightSceneManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Monster;

    public Text PlayerHealthText;
    public Text MonsterHealthText;

    private Fight fight;

    private Vector3 playerStartPos;
    private Vector3 monsterStartPos;

    private Vector3 attackMove = new Vector3(1, 0, 0);

    private bool isPlayerTurn = true;   
    //To get this to work, either have them be protected and fight inheirits from fightscenemanager
    // or we just pass it through the updatefight function. 


    void Start()
    {
        this.playerStartPos = this.Player.transform.position;
        this.monsterStartPos = this.Monster.transform.position;

        Monster theMonster = Core.theMonster;
        fight = new Fight(theMonster, Core.thePlayer, MonsterHealthText, PlayerHealthText);
    }

    void Update()
    {
        fight.updateFight(Player, Monster);
    }
}
    