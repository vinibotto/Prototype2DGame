using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Character2D : MonoBehaviour
    {
        public bool IsGrounded;
        public bool ShotTimer;

        public Animator animator;
        public GameObject bullet;
        public Transform positionLeft;
        public Transform positionRight;
        
        public float shotSpeed;
        public SpriteRenderer spriteRenderer;
        
        public int speed;
        public float Jumpforce;
        public Rigidbody2D rigidBody2d;

        public float shootTimer;
        public float shootCooldown;

        // Start is called before the first frame update
        public virtual void Start() 
        {
            IsGrounded = false;
            ShotTimer = false;
        }

        public virtual void Update() 
        {
            animator.SetBool("IsGrounded", IsGrounded);
            if (rigidBody2d.velocity.y <= 1)
            {
                rigidBody2d.velocity += Vector2.up * Physics2D.gravity.y * 2 * Time.deltaTime;
            }
        }

        protected virtual void CalculateShootingCooldown(float cooldown) 
        {
            if (ShotTimer)
                shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                ShotTimer = false;
                animator.SetBool("IsShooting", false);
                shootTimer = cooldown;
            }
        }

        protected virtual void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Ground")
            {
                IsGrounded = true;
                animator.SetBool("IsGrounded", true);
            }

            if (col.gameObject.tag == "Projectile") 
            {
                if (gameObject.tag == "Enemy")
                    ScoreScript.scoreValue++;
                
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }

        protected virtual void Shoot() 
        {
            if (!ShotTimer)
            {
                if (!spriteRenderer.flipX)
                {
                    GameObject newBullet = Instantiate(bullet, positionLeft.position, transform.rotation);
                    newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * -shotSpeed;
                }
                else
                {
                    GameObject newBullet = Instantiate(bullet, positionRight.position, transform.rotation);
                    newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * shotSpeed;
                }
                animator.SetBool("IsShooting", true);
                ShotTimer = true;
            }
        }

        protected virtual void Jump() 
        {
            if (IsGrounded)
            {
                rigidBody2d.AddForce(Vector2.up * Jumpforce);
                IsGrounded = false;
                animator.SetBool("IsGrounded", false);
                animator.SetBool("IsShooting", false);
            }
        }
    }
}
