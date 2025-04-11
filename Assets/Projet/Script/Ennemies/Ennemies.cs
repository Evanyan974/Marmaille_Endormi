using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ennemies : MonoBehaviour
{
    private int health;
    private float detectionRange;
    private float range;
    private float speed;
    private Transform player;

    public int Health { get => health; set => health = value; }
    public float DetectionRange { get => detectionRange; set => detectionRange = value; }
    public float Range { get => range; set => range = value; }

    public float Speed {get => speed; set => speed = value; }

    public Transform Player { get => player; set => player = value; }


    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void Patrol()
    {

    }

    public void Hit()
    {
        


    }

    public abstract void Attack(float detectionRange, float range);
    

    public void DropPower()
    {

    }
}
