using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField] int hp;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<MeshRenderer>().material.color = this.gameObject.GetComponent<MeshRenderer>().material.color;
    }
}
