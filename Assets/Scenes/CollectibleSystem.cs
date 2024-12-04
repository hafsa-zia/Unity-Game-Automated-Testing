using UnityEngine;

public class CollectibleSystem : MonoBehaviour
{
    public int TotalCollectibles { get; private set; }
    public int CollectedItems { get; private set; }

    private void Awake()
    {
        TotalCollectibles = 0;
        CollectedItems = 0;
    }

    public void AddCollectible()
    {
        TotalCollectibles++;
    }

    public void CollectItem()
    {
        if (CollectedItems < TotalCollectibles)
        {
            CollectedItems++;
        }
        else
        {
            Debug.LogWarning("No more items left to collect.");
        }
    }

    public bool AllItemsCollected()
    {
        return CollectedItems == TotalCollectibles;
    }
}
