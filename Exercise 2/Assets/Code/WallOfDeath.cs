using UnityEngine;

/// <summary>
/// Destroys wayward objects that run into it.
/// </summary>
public class WallOfDeath : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tank")
        {
            ScoreManager.IncreaseScore(other.gameObject, -50);
        }
        Destroy(other.gameObject);
    }
}
