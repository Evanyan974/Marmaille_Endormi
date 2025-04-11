using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ennemies : MonoBehaviour
{
    private int health;
    private float detectionRange;
    private float range;

    public int Health { get => health; set => health = value; }
    public float DetectionRange { get => detectionRange; set => detectionRange = value; }
    public float Range { get => range; set => range = value; }

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
