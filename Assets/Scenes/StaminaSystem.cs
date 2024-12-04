using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    public int MaxStamina { get; private set; } = 100; // Default max stamina
    public int CurrentStamina { get; private set; }

    private void Awake()
    {
        CurrentStamina = MaxStamina; // Initialize stamina to full on creation
    }

    // Allows external initialization of stamina values for testing or gameplay
    public void InitializeStamina(int maxStamina, int currentStamina)
    {
        MaxStamina = Mathf.Max(maxStamina, 0); // Ensure max stamina is non-negative
        CurrentStamina = Mathf.Clamp(currentStamina, 0, MaxStamina); // Clamp current stamina within valid range
    }

    public void DecreaseStamina(int amount)
    {
        if (amount < 0) throw new System.ArgumentException("Decrease amount cannot be negative.");
        CurrentStamina = Mathf.Max(CurrentStamina - amount, 0); // Ensure stamina doesn't go below zero
    }

    public void IncreaseStamina(int amount)
    {
        if (amount < 0) throw new System.ArgumentException("Increase amount cannot be negative.");
        CurrentStamina = Mathf.Min(CurrentStamina + amount, MaxStamina); // Ensure stamina doesn't exceed MaxStamina
    }
}
