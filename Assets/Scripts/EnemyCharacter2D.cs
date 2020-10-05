using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter2D : Character2D
{
    private GameObject Player;
    private float Range;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Player = GameObject.FindGameObjectWithTag("Player");
        shootTimer = 2f;
        shootCooldown = 2f;
    }

    // Update is called once per frame
    public override void Update()
    {
        CalculateShootingCooldown(shootCooldown);
        if (Player == null)
        {
            animator.SetBool("IsWalking", false);
        }
        else 
        {
            Range = Vector2.Distance(transform.position, Player.transform.position);

            if (Range > 10f)
            {
                animator.SetBool("IsWalking", true);
                bool isGoingRight = (transform.position.x < Player.transform.position.x);
                spriteRenderer.flipX = isGoingRight;
                transform.Translate(new Vector3(speed * Time.deltaTime * (isGoingRight ? 1 : -1), 0, 0));
            }
            else
            {
                animator.SetBool("IsWalking", false);
                if (IsGrounded)
                    Shoot();
            }

        }

        base.Update();
    }

}
