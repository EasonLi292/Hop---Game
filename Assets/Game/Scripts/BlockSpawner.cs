using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public List<GameObject> blockPrefabs; // The list of prefab game objects for the blocks that will be generated
    public float blockSpawnInterval = 1.0f; // The interval at which blocks should be spawned

    private bool canSpawnBlock = false; // A flag to determine whether the next block can be spawned

    private void Start()
    {
        // Start the block generation Coroutine
        StartCoroutine(GenerateBlocks());
    }

    private IEnumerator GenerateBlocks()
    {
        while (true) // This loop will run indefinitely
        {
            // Wait until the player lands on the previous block
            while (!canSpawnBlock)
            {
                yield return null;
            }

            // Generate a new block in the x or z direction, randomly
            float x = 0;
            float y = 0;
            float z = 0;
            if (Random.Range(0, 2) <1)
            {
                // Generate a new block in the x direction
                x = Random.Range(-1.5f, -4.0f);
            }
            else
            {
                // Generate a new block in the z direction
                z = Random.Range(1.5f, 4.0f);
            }
            Vector3 blockPosition = new Vector3(x, y, z);
           // Choose a random prefab from the blockPrefabs list
            int prefabIndex = Random.Range(0, blockPrefabs.Count-1);
            GameObject prefab = blockPrefabs[prefabIndex];

            // Instantiate the chosen prefab at the blockPosition
            Instantiate(prefab, blockPosition, Quaternion.identity);

            // Reset the canSpawnBlock flag
            canSpawnBlock = false;
        }
    }

    // This method is called when the player's character enters the trigger collider on the block
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // The player has landed on the block
            // Set the canSpawnBlock flag to true, allowing the next block to be spawned
            canSpawnBlock = true;
        }
    }
}

