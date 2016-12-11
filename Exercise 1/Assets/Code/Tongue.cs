using UnityEngine;
using System;

/// <summary>
/// Trigger tongue animation based on player input.
/// </summary>
public class Tongue : MonoBehaviour {
    /// <summary>
    /// Event handlers to call when the frog catches a yummy
    /// </summary>
    public event Action CaughtYummy;
	
    /// <summary>
    /// Check if the player wants to stick the tongue out yet.
    /// Called once per frame.
    /// </summary>
	internal void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Licking");
        }
	}

    /// <summary>
    /// Called when the tounge touches something.
    /// In this case, the yummy is the only thing to touch.
    /// </summary>
    /// <param name="other"></param>
    internal void OnTriggerEnter2D(Collider2D other) {
        CaughtYummy();
        Destroy(other.gameObject);
    }
}
