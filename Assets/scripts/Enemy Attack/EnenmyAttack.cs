using UnityEngine;

public class EnenmyAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform player;
    public LayerMask playerLayer;
    public Transform detectionPoint;
    public Transform attackPoint;
    public float findRange;
    public float attackRange;
    public float speed;

    private Transform enemyPosition;
    private Rigidbody2D rb;
    private AnimationStiuation enemySitiuation;
    private Animator anim;

    void Start()
    {
        enemyPosition = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        changAnimation(AnimationStiuation.Idle);

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
            changAnimation(AnimationStiuation.Idle);
        }
    }
    void chacing()
    {
        changAnimation(AnimationStiuation.Chasing);
        Vector2 direction = player.position - enemyPosition.position;
        rb.linearVelocity = direction * speed;
        Attacking();
    }
    void changAnimation(AnimationStiuation enemyAnim)
    {
        if (enemySitiuation == AnimationStiuation.Idle)
        {
            anim.SetBool("isidle", false);
        }
        else if (enemySitiuation == AnimationStiuation.Chasing)
        {
            anim.SetBool("ischasing", false);
        }
        else if (enemySitiuation == AnimationStiuation.Attacking)
        {
            anim.SetBool("isattacking", false);
        }

        enemySitiuation = enemyAnim;

        if (enemySitiuation == AnimationStiuation.Idle)
        {
            anim.SetBool("isidle", true);
        }
        else if (enemySitiuation == AnimationStiuation.Chasing)
        {
            anim.SetBool("ischasing", true);
        }
        else if (enemySitiuation == AnimationStiuation.Attacking)
        {
            anim.SetBool("isattacking", true);
        }
    }
    void Attacking()
    {
        Collider2D[] attack = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        if (attack.Length > 0)
        {
            changAnimation(AnimationStiuation.Attacking);
        }
        
    }
}

enum AnimationStiuation
{
    Idle,
    Chasing,
    Attacking,
}