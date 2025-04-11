using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Ennemies
{
    [SerializeField] private GameObject fireBreahtingZone;

    public GameObject FireBreathingZone
    {
        get { return fireBreahtingZone; }
        set { fireBreahtingZone = value;}
    }



    public Dragon() { }


    public Dragon(int health , float detectionRange, float range, float speed , Transform player , GameObject pouvoir)
    {
        Health = health;
        DetectionRange = detectionRange;
        Range = range;
        Speed = speed;
        Player = player;
        Pouvoir = pouvoir;
    }


    public override void Start()
    {
        fireBreahtingZone.SetActive(false);
        
    }

    public override void Attack(float detectionRange, float range)
    {
        base.Attack(detectionRange, range);
        if(Vector3.Distance(transform.position, Player.position) < detectionRange)
        {
            Debug.Log("Graouh!Crachage de feu ");
            fireBreahtingZone.SetActive(true);
        }
        
    }
}
