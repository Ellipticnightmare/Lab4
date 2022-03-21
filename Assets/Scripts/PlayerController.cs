﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : ActorController
{
    CharacterController chara;
    float horizontalDetect, verticalDetect;
    [Range(1, 6)]
    public int speed = 1;
    public Transform firePoint;
    private void Start()
    {
        chara = this.GetComponent<CharacterController>();
    }
    private void Update()
    {
        horizontalDetect = Input.GetAxisRaw("Horizontal");
        verticalDetect = Input.GetAxisRaw("Vertical");
        chara.Move(new Vector3(0, 0, verticalDetect) * speed * Time.deltaTime);

        this.gameObject.transform.Rotate(new Vector3(0, horizontalDetect * speed * Time.deltaTime, 0));
    }
    public override void fireBullet(Transform firePoint)
    {
        if (firedBullet == null)
            base.fireBullet(firePoint);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
            GameManager.TakeHit();
    }
}