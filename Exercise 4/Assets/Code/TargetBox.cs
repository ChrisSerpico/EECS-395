using UnityEngine;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreen;

    // boolean to make sure a box is only scored once 
    private bool isScored = false; 

    internal void Start() {
        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
    }

    internal void Update()
    {
        if (transform.position.x > OffScreen)
            Scored();
    }

    private void Scored()
    {
        if (isScored == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            ScoreKeeper.AddToScore(gameObject.GetComponent<Rigidbody2D>().mass);
            isScored = true; 
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Scored();
        }
    }
}
