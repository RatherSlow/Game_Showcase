using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [SerializeField]
    float hitPoints = 25;

    public void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        Debug.Log($"{gameObject.name} took {rawDamage} damage. Remaining HP: {hitPoints}");

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
