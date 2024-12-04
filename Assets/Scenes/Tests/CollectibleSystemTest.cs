using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class CollectibleSystemTest
{
    private GameObject collectibleManager;
    private CollectibleSystem collectibleSystem;

    [SetUp]
    public void SetUp()
    {
        collectibleManager = new GameObject("CollectibleManager");
        collectibleSystem = collectibleManager.AddComponent<CollectibleSystem>();
    }

    [Test]
    public void CollectibleSystem_AddCollectible_IncreasesTotal()
    {
        // Act
        collectibleSystem.AddCollectible();
        collectibleSystem.AddCollectible();

        // Assert
        Assert.AreEqual(2, collectibleSystem.TotalCollectibles);
    }

    [Test]
    public void CollectibleSystem_CollectItem_IncreasesCollectedCount()
    {
        // Arrange
        collectibleSystem.AddCollectible();
        collectibleSystem.AddCollectible();

        // Act
        collectibleSystem.CollectItem();

        // Assert
        Assert.AreEqual(1, collectibleSystem.CollectedItems);
    }

    [Test]
    public void CollectibleSystem_AllItemsCollected_ReturnsTrueWhenAllCollected()
    {
        // Arrange
        collectibleSystem.AddCollectible();
        collectibleSystem.AddCollectible();

        // Act
        collectibleSystem.CollectItem();
        collectibleSystem.CollectItem();

        // Assert
        Assert.IsTrue(collectibleSystem.AllItemsCollected());
    }

    [Test]
    public void CollectibleSystem_CollectItem_DoesNotExceedTotal()
    {
        // Arrange
        collectibleSystem.AddCollectible();

        // Act
        collectibleSystem.CollectItem();
        collectibleSystem.CollectItem(); // Attempt to collect more than available

        // Assert
        Assert.AreEqual(1, collectibleSystem.CollectedItems);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(collectibleManager);
    }
}
