using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Ennemies
{
    public override void Attack(float detectionRange, float range)
    {
        base.Attack(detectionRange, range);
        if (Vector3.Distance(transform.position, Player.position) < detectionRange)
        {
            Debug.Log("Graouh!Crachage de feu ");
        }
    }
}
