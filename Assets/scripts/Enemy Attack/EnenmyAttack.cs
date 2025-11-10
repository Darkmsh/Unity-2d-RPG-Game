using UnityEngine;

public class EnenmyAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform player;
    public LayerMask playerLayer;
    public Transform detectionPoint;
    public float findRange;
    public float speed;

    private Transform enemyPosition;
    private Rigidbody2D rb;
    private AnimationStiuation enemySitiuation;

    void Start()
    {
        enemyPosition = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

        float space = Vector2.Distance(enemyPosition.position, player.position);
        if (space <= findRange)
        {
            Collider2D[] findPlayer = Physics2D.OverlapCircleAll(detectionPoint.position, findRange, playerLayer);
            if (findPlayer.Length > 0)
            {
                chacing();
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
    void chacing()
    {
        Vector2 space = player.position - enemyPosition.position;
        rb.linearVelocity=space*speed;  
    }
}

enum AnimationStiuation
{
    Idle,
    Walking,
    Attacking,
}