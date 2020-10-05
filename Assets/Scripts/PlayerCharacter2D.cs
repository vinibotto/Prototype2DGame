using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCharacter2D : Character2D
{
    public PlayerCharacter2D() 
    {
        
    }

    public override void Start()
    {
        base.Start();

        shootTimer = .2f;
        shootCooldown = .2f;
    }
    // Update is called once per frame
    public override void Update()
    {
        CalculateShootingCooldown(shootCooldown);
        Movement();
        base.Update();
    }

    void Movement() 
    {
        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse)) 
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsShooting", false);
            spriteRenderer.flipX = true;
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsShooting", false);
            spriteRenderer.flipX = false;
            transform.Translate(new Vector3(-(speed * Time.deltaTime), 0, 0));
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
