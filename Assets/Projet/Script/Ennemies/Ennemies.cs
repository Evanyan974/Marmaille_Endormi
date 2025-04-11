using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Ennemies : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float detectionRange;
    [SerializeField] private float range;
    [SerializeField] private float speed;
    [SerializeField] private Transform player;

    [SerializeField]
    private GameObject pouvoir;

    public int Health { get => health; set => health = value; }
    public float DetectionRange { get => detectionRange; set => detectionRange = value; }
    public float Range { get => range; set => range = value; }

    public float Speed {get => speed; set => speed = value; }

    public Transform Player { get => player; set => player = value; }
    public GameObject Pouvoir { get => pouvoir; set => pouvoir = value; }

    public virtual void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Pouvoir = pouvoir;
    }


    public void Patrol()
    {

    }

    public void Hit()
    {
        


    }

    public virtual void Attack(float detectionRange, float range)
    {
        if (Vector3.Distance(transform.position, Player.position) < detectionRange)
        {
            Vector3 direction = (Player.position - transform.position).normalized;
            transform.position += direction * Speed * Time.deltaTime;
        }
    }
    

    public void DropPower()
    {
        GameObject power = Instantiate(Pouvoir);
        power.transform.position = this.transform.position;
    }

    public void OnDestroy()
    {
        DropPower();
    }
}
