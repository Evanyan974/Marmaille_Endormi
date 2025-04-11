using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Ennemies
{

    public Tank() { }


    public Tank(int health, float detectionRange, float range, float speed, Transform player, GameObject pouvoir)
    {
        Health = health;
        DetectionRange = detectionRange;
        Range = range;
        Speed = speed;
        Player = player;
        Pouvoir = pouvoir;
    }


     public override void Attack(float detectionRange, float range)
    {
        base.Attack(detectionRange, range);
        if (Vector3.Distance(transform.position, Player.position) < detectionRange)
        {
            Debug.Log("FEUUUUUUUUUUUU!!!!!");
        }
    }



    public override void Start()
    {
        
        new Tank(Health, DetectionRange, Range, Speed, Player, Pouvoir);
    }
}
