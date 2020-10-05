﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float timer;
    public GameObject particle;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) 
        {
            if(particle)
                Instantiate(particle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }

    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }
}
