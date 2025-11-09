using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    float speed = 4f;
    public Rigidbody2D rb;
    public Animator anim;

    private bool isknockback;
    void Start()
    {
        isknockback = false;
    }

    void Update()
    {


    }
    void FixedUpdate()
    {
        if (!isknockback)
        {

            float horizantal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            anim.SetFloat("horizantal", Mathf.Abs(horizantal));
            anim.SetFloat("vertical", Mathf.Abs(vertical));

            if (horizantal > 0 && transform.localScale.x < 0 || horizantal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            rb.linearVelocity = new Vector2(horizantal, vertical) * speed;
        }



    }
    void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    public void KnockBack(Transform enemy)
    {
        isknockback=true;
        Vector2 direction=transform.position - enemy.position;
        rb.linearVelocity=direction * 10;
       
    }
}
