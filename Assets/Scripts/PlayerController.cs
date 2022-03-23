using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : ActorController
{
    CharacterController chara;
    float horizontalDetect, verticalDetect;
    [Range(1, 6)]
    public float speed = 1.7f;
    public Transform firePoint;
    [Range(1, 10)]
    public float invincibilityTimer = 1;
    public static bool isShield;

    AudioSource plyShoot;
    AudioSource plyMove;
    bool isMoving = false;

    private void Start()
    {
        chara = this.GetComponent<CharacterController>();
        plyShoot = GetComponent<AudioSource>();
        plyMove = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (invincibilityTimer >= 0)
            invincibilityTimer -= Time.deltaTime;
        horizontalDetect = Input.GetAxisRaw("Horizontal");
        verticalDetect = Input.GetAxisRaw("Vertical");
        chara.Move(transform.up * speed * verticalDetect * Time.deltaTime);

        this.gameObject.transform.Rotate(new Vector3(0, 0, -horizontalDetect * speed * 100 * Time.deltaTime));

        if(verticalDetect != 0)
            isMoving = true;
        else
            isMoving = false;
        if (isMoving)
        {
          if (!plyMove.isPlaying)
          plyMove.Play();

        }
        else
          plyMove.Stop();

        if (Input.GetKeyDown("space"))
        {
            //if ()
            //{
              plyShoot.Play();
            //}
              fireBullet(firePoint);
        }
    }
    public override void fireBullet(Transform firePoint)
    {
        if (firedBullet == null)
            base.fireBullet(firePoint);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && invincibilityTimer <= 0)
            GameManager.TakeHit();
    }
}
