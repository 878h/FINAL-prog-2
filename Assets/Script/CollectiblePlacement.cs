using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePlacement : MonoBehaviour //not implemented, disregard this
{
    public GameObject collectiblePrefab;
    public int maxCollectibles = 1;
    public float minDistanceFromPlayer = 2f;
    public float collectibleRadius = 5f;

    private List<GameObject> collectibles = new List<GameObject>();

    void Start()
    {
        GenerateCollectibles();
    }

    public void GenerateCollectibles()
    {
        for (int i = 0; i < maxCollectibles; i++)
        {
            Vector3 randomOffset = Random.insideUnitCircle * collectibleRadius;
            Vector3 collectiblePosition = transform.position + new Vector3(randomOffset.x, 0, randomOffset.y);

            if (Vector3.Distance(collectiblePosition, transform.position) < minDistanceFromPlayer)
            {
                continue;
            }

            GameObject newCollectible = Instantiate(collectiblePrefab, collectiblePosition, Quaternion.identity);
            collectibles.Add(newCollectible);
        }
    }

    public void CollectCollectible(GameObject collectedCollectible)
    {
        collectibles.Remove(collectedCollectible);
        Destroy(collectedCollectible);
        GenerateCollectibles();
    }

    public GameObject GetNearestPickup(Vector3 position)
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPickup = null;

        foreach (GameObject collectible in collectibles)
        {
            float distance = Vector3.Distance(position, collectible.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestPickup = collectible;
            }
        }

        return nearestPickup;
    }
}

