using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Prefab for the plane object
    public GameObject planePrefab;

    // Arrays of top and bottom colors for the gradient
    public Color[] topColors;
    public Color[] bottomColors;

    // Speed at which the colors should change
    public float colorChangeSpeed = 1.0f;

    // Current indices of the top and bottom colors
    private int topColorIndex = 0;
    private int bottomColorIndex = 0;

    // Timer to keep track of the color change progress
    private float colorTimer = 0.0f;

    // Offset between each plane
    float planeOffset = 50f;

    // Size of the plane
    Vector3 planeSize;

    // Current plane
    GameObject currentPlane;

    // Player game object
    GameObject playerObject;

    // Player position
    Vector3 playerPos = new Vector3(0, 0, 0);

    private void Start()
    {
        // Get a reference to the player game object
        playerObject = GameObject.Find("Player");
        // Set the sky's initial gradient colors
        RenderSettings.fogColor = topColors[topColorIndex];
        RenderSettings.fogDensity = 0.01f;
        Camera.main.backgroundColor = bottomColors[bottomColorIndex];

        // Set the current plane to the first plane that is instantiated
        currentPlane = Instantiate(planePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        currentPlane.transform.parent = transform;

        // Set the plane size to the size of the current plane
        planeSize = currentPlane.GetComponent<SpriteRenderer>().bounds.size;

    }

    private void Update()
    {
        // Update the player position
        playerPos = playerObject.transform.position;

        // Increment the color timer
        colorTimer += Time.deltaTime * colorChangeSpeed;

        // Interpolate the gradient colors based on the color timer
        RenderSettings.fogColor = Color.Lerp(topColors[topColorIndex], topColors[(topColorIndex + 1) % topColors.Length], colorTimer);
        Camera.main.backgroundColor = Color.Lerp(bottomColors[bottomColorIndex], bottomColors[(bottomColorIndex + 1) % bottomColors.Length], colorTimer);

        // If the color timer has reached 1.0, reset it and select the next color in the array
        if (colorTimer >= 1.0f)
        {
            colorTimer = 0.0f;
            topColorIndex = (topColorIndex + 1) % topColors.Length;
            bottomColorIndex = (bottomColorIndex + 1) % bottomColors.Length;
        }

        // If the player has moved three quarters across the current plane in either the x or z direction,
        // instantiate a new plane and set it as the current plane
        if (playerPos.x > planeSize.x * 0.75f || playerPos.z > planeSize.z * 0.75f)
        {
            // Calculate the position of the new plane
            float xPos = currentPlane.transform.position.x + planeOffset;
            float zPos = currentPlane.transform.position.z + planeOffset;

        // Instantiate the new plane
            GameObject newPlane = Instantiate(planePrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
            newPlane.transform.parent = transform;

        // Set the new plane as the current plane
            currentPlane = newPlane;
        }


    }

}