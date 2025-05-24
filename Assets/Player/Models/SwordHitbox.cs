using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public int damage = 10;
    public bool canDamage = false;
    public LayerMask enemyLayer;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger with: " + other.name);

        if (!canDamage) return;

        if ((enemyLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            Debug.Log("Hit enemy: " + other.name);

            // Try to send the damage message
            HitManager hitManager = other.GetComponent<HitManager>();
            if (hitManager != null)
            {
                hitManager.SendMessage("Hit", damage);
            }
        }
    }
}
