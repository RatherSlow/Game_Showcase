using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public int damage = 10;
    public bool canDamage = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!canDamage) return;

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy: " + other.name);
            // other.GetComponent<EnemyHealth>()?.TakeDamage(damageAmount);
        }
    }

}
