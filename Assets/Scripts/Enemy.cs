using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;                                                                             // Speed of the enemy
    private Rigidbody enemyRb;                                                                      // Rigidbody of the enemy
    private GameObject player;                                                                      // GameObject of the player
    private float masterPower = 5.0f;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();                                                        // Get the Rigidbody component of the enemy
        player = GameObject.Find("Player");                                                         // Get the GameObject of the player.
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;        // The direction of the enemy to the player, in Vector3.
        enemyRb.AddForce(lookDirection * speed);                                                    // Move the enemy towards the player.

        // Enemies are destroyed when they fall.
        if (transform.position.y < -8)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("EnemyExpert"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromEnemy = collision.gameObject.transform.position - transform.position;

            playerRb.AddForce(awayFromEnemy * masterPower, ForceMode.Impulse);
        }
    }
}
