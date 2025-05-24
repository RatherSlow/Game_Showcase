using System.Collections;
using UnityEngine;


public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    private SwordHitbox swordHitbox; 
    private bool isAttacking = false;

    public float attackDuration = 45f; // Total animation time
    public float damageWindowStart = 0.2f;
    public float damageWindowEnd = 30f;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        swordHitbox = GetComponentInChildren<SwordHitbox>();
    }

    public void Attack()
    {
        if (isAttacking) return;

        isAttacking = true;
        animator.SetTrigger("LightAttack");
        StartCoroutine(PerformAttack());
        Debug.Log("Attack Button Pressed");
    }

    IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(damageWindowStart);
        swordHitbox.canDamage = true;

        yield return new WaitForSeconds(damageWindowEnd - damageWindowStart);
        swordHitbox.canDamage = false;

        yield return new WaitForSeconds(attackDuration - damageWindowEnd);
        isAttacking = false;
    }
}
