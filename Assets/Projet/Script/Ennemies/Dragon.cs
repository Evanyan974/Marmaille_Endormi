using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Ennemies
{
    public override void Attack(float detectionRange, float range)
    {
        if (Vector3.Distance(transform.position, Player.position) < detectionRange)
        {
            Vector3 direction = (Player.position - transform.position).normalized;
            transform.position += direction * Speed * Time.deltaTime;



        }
    }
}
