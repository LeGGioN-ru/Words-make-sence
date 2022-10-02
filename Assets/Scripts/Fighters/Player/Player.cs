using UnityEngine.Events;

public class Player : Fighter
{
    public void IncreaseHealth(int health)
    {
        MaxHealth += health;
    }

    public void DecreaseHealth(int health)
    {
        MaxHealth -= health;
    }

    public void IncreaseMana()
    {

    }

    public void DecreaseMana()
    {

    }
}
