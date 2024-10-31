using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float roadCenterX = 2.4901f;
    private float roadWidth = 20f;
    private float spawnPosZ = 63.2f;

    void Start()
    {
        InvokeRepeating("SpawnAllAnimals", 2f, 1.5f);
    }

    void SpawnAllAnimals()
    {
        if (animalPrefabs == null || animalPrefabs.Length == 0)
        {
            Debug.LogError("No animal prefabs assigned to spawner!");
            return;
        }

        // Loop through each prefab in the animalPrefabs array
        foreach (GameObject animalPrefab in animalPrefabs)
        {
            // Generate a random x position within the road width
            float spawnX = Random.Range(roadCenterX - (roadWidth / 2), roadCenterX + (roadWidth / 2));
            Vector3 spawnPos = new Vector3(spawnX, 0, spawnPosZ);

            // Make each animal face towards the start of the road (180 degrees around Y axis)
            Quaternion rotation = Quaternion.Euler(0, 180, 0);

            // Instantiate the animal prefab at the random position with the specified rotation
            Instantiate(animalPrefab, spawnPos, rotation);
        }
    }
}
