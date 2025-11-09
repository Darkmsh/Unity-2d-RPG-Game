using JetBrains.Annotations;
using UnityEngine;


public class Enemy_Combat_test : MonoBehaviour
{
    public int damage;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask player;

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player);
        if (hits.Length > 0 )
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);
            hits[0].GetComponent<movement>().KnockBack(transform);
        }
    }
}
