using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public int MaxInventorySize { get; private set; } = 5; // Maximum number of items the player can carry
    private List<string> inventory = new List<string>(); // List to hold item names

    public IReadOnlyList<string> Inventory => inventory.AsReadOnly(); // Read-only access to inventory items

    public bool AddItem(string item)
    {
        if (inventory.Count >= MaxInventorySize)
            return false; // Cannot add more items if the inventory is full

        inventory.Add(item);
        return true; // Item added successfully
    }

    public bool RemoveItem(string item)
    {
        return inventory.Remove(item); // Removes item if found and returns true, otherwise false
    }

    public bool IsFull() => inventory.Count >= MaxInventorySize; // Checks if the inventory is full
}
