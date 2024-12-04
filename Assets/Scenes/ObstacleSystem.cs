using UnityEngine;

public class ObstacleSystem : MonoBehaviour
{
    public int ObstaclesCrossed { get; private set; } = 0;

    public bool CanCrossObstacle(int requiredStamina, int requiredMana, int currentStamina, int currentMana)
    {
        if (requiredStamina < 0 || requiredMana < 0)
            throw new System.ArgumentException("Required stamina and mana cannot be negative.");

        return currentStamina >= requiredStamina && currentMana >= requiredMana;
    }

    public void CrossObstacle()
    {
        ObstaclesCrossed++;
    }
}
