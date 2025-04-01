using UnityEngine;

public abstract class Inhabitant
{
    protected int currentHP;
    protected int maxHP;
    protected int ac;
    protected string name;

    public Inhabitant(string name)
    {
        this.name = name;
        this.maxHP = Random.Range(30, 50);
        this.currentHP = this.maxHP;
        this.ac = Random.Range(10, 20);
    }

    public int getCurrentHP()
    {
        return this.currentHP;
    }

    public int getMaxHP()
    {
        return this.maxHP;
    }

    public int getAC()
    {
        return this.ac;
    }

    public void takeDamage(int damage)
    {
        this.currentHP = currentHP - damage;
    }

    public void heal(int healingAmount)
    {
        int healthCheck = this.currentHP + healingAmount;
        if (healthCheck > this.maxHP)
        {
            this.currentHP = this.maxHP;
        }
        else
        {
            this.currentHP += healingAmount;
        }
    }

    public string getName()
    {
        return this.name;
    }

}