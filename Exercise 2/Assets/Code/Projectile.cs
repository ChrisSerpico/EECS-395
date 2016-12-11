using UnityEngine;

public class Projectile : MonoBehaviour {
    /// <summary>
    /// What game object (tank) fired this projectile.
    /// </summary>
    public GameObject Creator;

    /// <summary>
    /// The speed at which projections should move
    /// </summary>
    public float Speed = 5f;
    
    /// <summary>
    /// The distance from the center past which the projectile
    /// has moved off screen and should be destroyed.
    /// </summary>
    public float Border = 20f;

    /// <summary>
    /// Velocity vector at which this projectile is moving
    /// </summary>
    private Vector3 velocity;

    /// <summary>
    /// Called by the TankController.
    /// Initializes the state of the Projectile.
    /// </summary>
    /// <param name="creator">The GameObject of the tank firing this projectile</param>
    /// <param name="initialPosition">Where to initially place the projectile</param>
    /// <param name="direction">What direction the projectile should move in</param>
    public void Init(GameObject creator, Vector3 initialPosition, Vector3 direction)
    {
        Creator = creator;
        transform.position = initialPosition;
        velocity = direction * Speed;
    }

    void Update()
    {
        transform.position += (velocity * Time.deltaTime); 

        if(Mathf.Abs(transform.position.x) > Border || Mathf.Abs(transform.position.y) > Border)
        {
            Destroy(this.gameObject);
        }
    }
}
