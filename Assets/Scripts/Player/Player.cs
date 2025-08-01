using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    public static event Action OnPlayerDied;
    public static event Action<int> OnScoreChanged;

    private Rigidbody rb;
    private int totalCollectibles;
    private int collectedCount;
    private int totalEnemies;
    private int enemiesTouched;

    private bool isGrounded = true;
    private bool hasEnded = false;
    private int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        collectedCount = 0;
        enemiesTouched = 0;

        Debug.Log("Found enemies: " + totalEnemies); // För felsökning

        OnScoreChanged?.Invoke(score);
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0f, v).normalized;
        Vector3 velocity = move * moveSpeed;

        Vector3 currentVelocity = rb.velocity;
        rb.velocity = new Vector3(velocity.x, currentVelocity.y, velocity.z);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasEnded) return;

        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            collectedCount++;
            score += 10;
            OnScoreChanged?.Invoke(score);

            if (collectedCount >= totalCollectibles)
            {
                hasEnded = true;
                GameManager.Instance.WinGame();
            }
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);

            enemiesTouched++;
            Debug.Log("Enemy touched! Count: " + enemiesTouched + " / " + totalEnemies);

            GameManager.Instance.DamagePlayer(50);

            if (enemiesTouched >= totalEnemies)
            {
                Debug.Log("All enemies touched – triggering Game Over");
                hasEnded = true;
                GameManager.Instance.GameOver();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}