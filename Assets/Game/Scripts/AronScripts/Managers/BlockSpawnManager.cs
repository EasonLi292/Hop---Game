using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnManager : MonoBehaviour
{
    // Prefab to Spawn
    [Header("Prefab")]
    public GameObject Block;

    // First Blocks in the Game (non-generated)
    [Header("First Blocks (Non-Generated)")]
    public GameObject FirstBlock;
    public GameObject SpawnBlock;

    [Header("Minimum and Maximum Distance Changes from the previous Block")]
    public int MinDistanceChange = 3;
    public int MaxDistanceChange = 6;

    // The position of the previous block
    private Vector3 previousBlockPosition; 

    // List of Blocks Created 
    private List<GameObject> SpawnedBlocks; 

    // Player Reference
    private GameObject Player; 

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Previous Block
        previousBlockPosition = FirstBlock.transform.position;

        // Initialize List 
        SpawnedBlocks = new List<GameObject>();
        SpawnedBlocks.Add(SpawnBlock);
        SpawnedBlocks.Add(FirstBlock);

        // Initialize Player 
        Player = GameObject.Find("Player");
    }

    public void NewBlock() {
        // Change in Z or Change in X?
        int randomDirection = Random.Range(0, 2);
        // Change between min and max distance
        int randomDistance = Random.Range(MinDistanceChange, MaxDistanceChange+1);

        // Change in Z 
        if (randomDirection == 0) {
            // Calculate New Block Position
            Vector3 newBlockPosition = new Vector3(previousBlockPosition.x, previousBlockPosition.y, previousBlockPosition.z + randomDistance);
            // Create New Block
            GameObject newBlock = Instantiate(Block, newBlockPosition, Quaternion.identity);
            // Add New Block to List 
            SpawnedBlocks.Add(newBlock);
            
            // Update Previous Block
            previousBlockPosition = newBlockPosition;

            // Notify Player Direction is Z 
            Player.GetComponent<FloatingController>().SetMovementForward(true);
        }
        // Change in X 
        else {
            // Calculate New Block Position
            Vector3 newBlockPosition = new Vector3(previousBlockPosition.x + randomDistance, previousBlockPosition.y, previousBlockPosition.z);
            // Create New Block
            GameObject newBlock = Instantiate(Block, newBlockPosition, Quaternion.identity);
            // Add New Block to List 
            SpawnedBlocks.Add(newBlock);
            
            // Update Previous Block
            previousBlockPosition = newBlockPosition;

            // Notify Player Direction is X 
            Player.GetComponent<FloatingController>().SetMovementForward(false);
        }
    }
}
