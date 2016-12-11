using UnityEngine;

/// <summary>
/// Just a simple component to keep track of the bounds of the arena
/// and propose locations to respawn objects
/// </summary>
public class SpawnController : MonoBehaviour
{
    // Screen bounds
    public static float XMin;
    public static float XMax;
    public static float YMin;
    public static float YMax;

    // Fill in within editor with walls defining the boundaries of the arena
    public GameObject LeftWall;
    public GameObject RightWall;
    public GameObject TopWall;
    public GameObject BottomWall;

	// Note the bounds of the arena.
	internal void Start ()
	{
	    XMin = LeftWall.transform.position.x;
	    XMax = RightWall.transform.position.x;
        YMin = BottomWall.transform.position.y;
        YMax = TopWall.transform.position.y;
    }

    /// <summary>
    /// Return a random location within the arena that is at least radius units from any other objects.
    /// </summary>
    /// <param name="radius">Safety distance for placement</param>
    /// <returns>Free location</returns>
    public static Vector2 FindFreeLocation(float radius)
    {
        bool isClear = false;
        float x = 0, y = 6;

        while (!isClear)
        {
            x = Random.Range(XMin, XMax);
            y = Random.Range(YMin, YMax);

            if (Physics2D.CircleCast(new Vector2(x, y), radius, new Vector2(0, 0)).collider == null)
            {
                isClear = true; 
            }
        }

        return new Vector2(x, y);
    }
}
