using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pow_IronKnight : Power
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        collision.gameObject.AddComponent<Pow_IronKnight>();
    }
}
